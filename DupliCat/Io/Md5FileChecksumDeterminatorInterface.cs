namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents the interface of any MD5 checksum determinator.
	/// </summary>
	internal interface Md5FileChecksumDeterminatorInterface
	{
		/// <summary>
		/// Determines the MD5 checksum.
		/// </summary>
		/// <returns>The determined MD5 checksum.</returns>
		string Determine();
	}
}
