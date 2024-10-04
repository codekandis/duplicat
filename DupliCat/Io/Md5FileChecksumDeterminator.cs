using System;
using System.IO;
using System.Security.Cryptography;
using CodeKandis.DupliCat.Data;
using File = System.IO.File;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents a MD5 file checksum determinator.
/// </summary>
internal class Md5FileChecksumDeterminator:
	Md5FileChecksumDeterminatorInterface
{
	/// <inheritdoc/>
	public virtual string Determine( FileInterface file )
	{
		using MD5    md5    = MD5.Create();
		using Stream stream = File.OpenRead( file.Path );

		byte[] hash = md5.ComputeHash( stream );

		return BitConverter
			.ToString( hash )
			.Replace( "-", "" )
			.ToLowerInvariant();
	}
}
