using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FindDupes2
{
	public partial class Form1 : Form
	{
		static BackgroundWorker bw;
		Search search;
		DataTable duplicates = new DataTable();
		FileHasher fileHasher;

		public Form1()
		{
			InitializeComponent();

			fileHasher = new FileHasher();

			//set up the datatable we are binding to the dataGridView
			//this is much faster than adding rows directly, manually
			duplicates.Columns.Add("Size", System.Type.GetType("System.String"));
			duplicates.Columns.Add("Path", System.Type.GetType("System.String"));
			duplicates.Columns.Add("Group", System.Type.GetType("System.Int32"));
			var bs = new BindingSource();
			bs.DataSource = duplicates;
			dataGridView1.DataSource = bs;
			dataGridView1.Columns["Path"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dataGridView1.Columns["Group"].Visible = false;

			//set up the background worker thread 
			bw = new BackgroundWorker();
			//mandatory. Otherwise will throw an exception when calling ReportProgress method  
			bw.WorkerReportsProgress = true;
			//mandatory. Otherwise we would get an InvalidOperationException when trying to cancel the operation
			bw.WorkerSupportsCancellation = true;
			bw.DoWork += bw_DoWork;
			bw.ProgressChanged += bw_ProgressChanged;
			bw.RunWorkerCompleted += bw_RunWorkerCompleted;

			cboMinSize.SelectedItem = "10MB"; //set default minimum size
		}

		void btnBrowse_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.SelectedPath = txtSearchFolder.Text;
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
				txtSearchFolder.Text = folderBrowserDialog1.SelectedPath;
		}

		void btnQuit_Click(object sender, EventArgs e)
		{
			if (bw.IsBusy)
				bw.CancelAsync();
			Application.Exit();
		}

		void btnGo_Click(object sender, EventArgs e)
		{
			if (txtSearchFolder.Text.Trim() == "" || !Directory.Exists(txtSearchFolder.Text))
			{
				MessageBox.Show("Directory does not exist.");
				return;
			}

			var search = SetupSearch();
			SetUiEnabled(false);

			//do the search
			bw.RunWorkerAsync(search);
		}

		Search SetupSearch()
		{
			//clear any old output from the UI
			txtFilesCompared.Text = "";
			txtPotentialSavings.Text = "";
			txtTotalFileCount.Text = "";
			txtTotalFileCount.Text = "";
			txtTotalDirectoryCount.Text = "";
			txtDuplicateCount.Text = "";
			//clear the results datatable bound to the datagridview
			duplicates.Rows.Clear();

			search = new Search(GetMinFileSize(), txtSearchFolder.Text);
			return search;
		}

		private int GetMinFileSize()
		{
			int minFileSize = 0;
			switch (cboMinSize.SelectedItem.ToString())
			{
				case "0":
					minFileSize = 0;
					break;
				case "10kB":
					minFileSize = 10 * 1024;
					break;
				case "100kB":
					minFileSize = 100 * 1024;
					break;
				case "1MB":
					minFileSize = 1048576;
					break;
				case "10MB":
					minFileSize = 10 * 1048576;
					break;
				case "100MB":
					minFileSize = 100 * 1048576;
					break;
				case "1GB":
					minFileSize = 1073741824;
					break;
			}
			return minFileSize;
		}

		DateTime uiLastUpdated = DateTime.Now;
		void WalkDirectoryTree(DirectoryInfo di, DoWorkEventArgs e, Search search)
		{
			try
			{
				//loop through all file for this directory
				foreach (var fi in di.EnumerateFiles())
				{
					if (bw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					search.TotalFileCount++;

					//update the UI every once in a while
					int minUiUpdateIntervalsMs = 500;
					var currentTime = DateTime.Now;
					if ((currentTime - uiLastUpdated).TotalMilliseconds >= minUiUpdateIntervalsMs)
					{
						uiLastUpdated = currentTime;
						bw.ReportProgress(0);
					}

					//create a file entry and check for duplicates
					try
					{
						//make sure the file exceeds the minimum size before continuing
						if (fi.Length < search.MinFileSize)
							continue;
						search.FileCountExceedingMinSize++;

						var skipFile = false;
						var firstInstance = GetFirstInstance(fi, search, out skipFile);
						if (skipFile)
							continue;
						if (firstInstance == null)
							search.FileEntries.Add(fi.FullName, new FileEntry(fi.Name, fi.Length));
						else
						{
							firstInstance.AddDuplicate(fi);
							search.DuplicateFileCount++;
							search.PotentialSpaceSavingsBytes += fi.Length;
						}
					}
					catch (FileNotFoundException) { }
				}

				//loop through all sub-directories
				foreach (var d in di.EnumerateDirectories())
				{
					search.TotalDirectoryCount++;
					if (bw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					search.TotalDirectoryCount++;

					WalkDirectoryTree(d, e, search);
				}
			}
			catch (UnauthorizedAccessException) { }
		}

		FileEntry GetFirstInstance(FileInfo currentFile, Search search, out bool skipFile)
		{
			//if we are not matching on names, then skip zero-length files
			if (currentFile.Length == 0 && !chkMatchNames.Checked)
			{
				skipFile = true;
				return null;
			}

			IEnumerable<KeyValuePair<string, FileEntry>> candidateFiles = search.FileEntries
				.Where(f => f.Value.Size == currentFile.Length && (!chkMatchNames.Checked || f.Value.Name == currentFile.Name));

			skipFile = false;
			foreach (var candidateFile in candidateFiles)
			{
				var fileEntry = candidateFile.Value;
				string currentFileHash = fileHasher.GetMD5Hash(currentFile.FullName);

				// if we can't get the current file hash, then the file is locked so we need to skip it, since we can't accurately compare
				if (currentFileHash == null)
				{
					skipFile = true;
					return null;
				}
				if (fileEntry.Hash == null)
				{
					fileEntry.Hash = fileHasher.GetMD5Hash(candidateFile.Key);
					if (fileEntry.Hash == null)
						continue;
				}

				if (currentFileHash == fileEntry.Hash)
					return fileEntry;
			}
			return null;
		}

		void btnCancel_Click(object sender, EventArgs e)
		{
			// notify background worker we want to cancel the operation.
			// this code doesn't actually cancel or kill the thread that is executing the job.
			if (bw.IsBusy)
				bw.CancelAsync();
		}

		void SetUiEnabled(bool enabled)
		{
			cboMinSize.Enabled = enabled;
			chkMatchNames.Enabled = enabled;
			btnGo.Enabled = enabled;
			txtSearchFolder.Enabled = enabled;
			btnBrowse.Enabled = enabled;
			btnCancel.Enabled = !enabled;
		}

		//This method is executed in a separate thread created by the background worker.  
		//so don't try to access any UI controls here!! (unless you use a delegate to do it)  
		//this attribute will prevent the debugger to stop here if any exception is raised.  
		//[System.Diagnostics.DebuggerNonUserCodeAttribute()]  
		void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			//NOTE: we shouldn't use a try catch block here (unless you rethrow the exception)  
			//the backgroundworker will be able to detect any exception on this code.  
			//if any exception is produced, it will be available to you on   
			//the RunWorkerCompletedEventArgs object, method backgroundWorker1_RunWorkerCompleted  
			e.Result = "";
			Search search = (Search)e.Argument;
			bw.ReportProgress(0, "Searching...\r\n");
			var di = new DirectoryInfo(search.SearchFolder.Trim());
			WalkDirectoryTree(di, e, search);
		}

		void WriteDuplicateFiles()
		{
			var sortedEntries = (from entry in search.FileEntries
								 where entry.Value.HasDuplicates
								 orderby entry.Value.Size descending
								 select entry);
			int groupCtr = 0;
			foreach (var f in sortedEntries)
			{
				var fileEntry = f.Value;
				groupCtr++;
				//write out file path
				duplicates.Rows.Add(Utility.FileSize(f.Value.Size), f.Key, groupCtr);
				//write out duplicates filepaths
				foreach (var d in fileEntry.Duplicates)
					duplicates.Rows.Add("", d.FullName, groupCtr);
			}

			//set alternating highlights
			foreach (DataGridViewRow r in dataGridView1.Rows)
				if ((int)r.Cells["Group"].Value % 2 == 0)
					r.DefaultCellStyle.BackColor = Color.AliceBlue;
		}

		//This event is raised on the main thread.
		//It is safe to access UI controls here.
		void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			UpdateUi();
		}

		void UpdateUi()
		{
			txtTotalFileCount.Text = search.TotalFileCount.ToString("N0");
			txtTotalDirectoryCount.Text = search.TotalDirectoryCount.ToString("N0");
			txtFilesCompared.Text = search.FileCountExceedingMinSize.ToString("N0");
			txtDuplicateCount.Text = search.DuplicateFileCount.ToString("N0");
			txtPotentialSavings.Text = Utility.FileSize(search.PotentialSpaceSavingsBytes);
		}

		void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UpdateUi();
			WriteDuplicateFiles();
			search.Dispose();

			if (e.Error != null)
				throw e.Error;

			SetUiEnabled(true);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var dlgResult = MessageBox.Show(String.Format("Delete the {0} selected files?", dataGridView1.SelectedRows.Count.ToString("N0")), "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dlgResult == DialogResult.Yes)
			{
				foreach (DataGridViewRow x in dataGridView1.SelectedRows)
				{
					File.Delete(x.Cells[1].Value.ToString());
					dataGridView1.Rows.Remove(x);
				}
			}
		}

		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			btnDelete.Enabled = dataGridView1.SelectedRows.Count > 0;
		}
	}
}
