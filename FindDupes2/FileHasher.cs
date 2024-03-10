using System;
using System.IO;
using System.Security.Cryptography;

public class FileHasher : IDisposable
{

	private readonly MD5 md5;

	public FileHasher()
	{
		md5 = MD5.Create();
	}

	public string GetMD5Hash(string filePath)
	{
		try
		{
			using var stream = new BufferedStream(File.OpenRead(filePath), 1200000);
			byte[] checksum = md5.ComputeHash(stream);
			return BitConverter.ToString(checksum).Replace("-", String.Empty);
		}
		catch (IOException)
		{
			return null;
		}
	}

	public void Dispose()
	{
		md5.Dispose();
	}
}
