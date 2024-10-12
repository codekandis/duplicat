namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any file path count extensioner.
/// </summary>
internal interface FilePathCountExtensionerInterface
{
	/// <summary>
	/// Gets the count extension of the file path.
	/// </summary>
	/// <param name="path">The path of the file.</param>
	/// <returns>The count extension of the file path.</returns>
	string DetermineCountExtension( string path );
}
