using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FindDupes2
{
    class Utility
    {
        /// <summary>
        /// returns null if the file cannot be accesseed to compute hash
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetMD5Hash(string filePath)
        {
            try
            {
                using (var stream = new BufferedStream(File.OpenRead(filePath), 1200000))
                {
                    var md5 = new MD5CryptoServiceProvider();
                    byte[] checksum = md5.ComputeHash(stream);
                    return BitConverter.ToString(checksum).Replace("-", String.Empty);
                }
            }
            catch (System.IO.IOException)
            {
                return null;
            }

        }

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
