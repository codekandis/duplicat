namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents the interface of any file extension lower caser.
	/// </summary>
	internal interface FileExtensionLowerCaserInterface
	{
		/// <summary>
		/// Lower cases the file extension.
		/// </summary>
		/// <param name="path">The path of the file to lower case its extension.</param>
		/// <returns>The new path of the file.</returns>
		string LowerCase( string path );
	}
}
