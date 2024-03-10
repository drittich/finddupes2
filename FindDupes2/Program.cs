using System;
using System.Drawing;
using System.Windows.Forms;

namespace FindDupes2
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

			Application.SetDefaultFont(new Font(new FontFamily("Segoe UI"), 8f));

			Application.Run(new Form1());
		}
	}
}
