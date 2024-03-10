using System;
using System.Collections.Generic;
using System.IO;

namespace FindDupes2
{
	class FileEntry
	{

		//constructor
		public FileEntry(string name, long size)
		{
			Name = name;
			Size = size;
		}

		public string Name
		{
			get;
			set;
		}

		public long Size
		{
			get;
			set;
		}

		public bool HasDuplicates
		{
			get
			{
				return Duplicates != null && Duplicates.Count > 0;
			}
		}

		public List<Duplicate> Duplicates
		{
			get;
			set;
		}

		public string Hash
		{
			get;
			set;
		}

		public void AddDuplicate(FileInfo duplicateFileInfo)
		{
			if (Duplicates == null)
				Duplicates = new List<Duplicate>();
			Duplicates.Add(new Duplicate(duplicateFileInfo.FullName, duplicateFileInfo.LastWriteTime));
		}

		public class Duplicate
		{
			public Duplicate(string fullName, DateTime lastModified)
			{
				FullName = fullName;
				LastModified = lastModified;
			}

			public string FullName
			{
				get; set;
			}
			public DateTime LastModified
			{
				get; set;
			}
		}
	}
}
