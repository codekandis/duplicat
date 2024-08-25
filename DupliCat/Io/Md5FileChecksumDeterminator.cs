using System;
using System.IO;
using System.Security.Cryptography;
using CodeKandis.DupliCat.Data;
using File = System.IO.File;

namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents a MD5 file checksum determinator.
	/// </summary>
	internal class Md5FileChecksumDeterminator:
		Md5FileChecksumDeterminatorInterface
	{
		/// <summary>
		/// Stores the file to determine its MD5 checksum.
		/// </summary>
		private FileInterface file;

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="file">The file to determine its MD5 checksum.</param>
		public Md5FileChecksumDeterminator( FileInterface file )
		{
			this.file = file;
		}

		/// <inheritdoc/>
		public virtual string Determine()
		{
			using MD5 md5 = MD5.Create();
			using Stream stream = File.OpenRead( this.file.Path );

			byte[] hash = md5.ComputeHash( stream );

			return BitConverter
				.ToString( hash )
				.Replace( "-", "" )
				.ToLowerInvariant();
		}
	}
}
