namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any registered paths.
/// </summary>
internal interface RegisteredFilePathsInterface
{
	/// <summary>
	/// Counts a file path.
	/// </summary>
	/// <param name="filePath">The file path to count.</param>
	/// <returns>The count of the file path.</returns>
	int Count( string filePath );
}
