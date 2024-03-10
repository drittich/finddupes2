using System;

namespace FindDupes2
{
	class Utility
	{
		public static string FileSize(long size)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			int order = 0;
			while (size >= 1024 && order + 1 < sizes.Length)
			{
				order++;
				size = size / 1024;
			}
			return String.Format("{0:0.##} {1}", size, sizes[order]);
		}
	}
}
