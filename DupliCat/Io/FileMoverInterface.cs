namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any file mover.
/// </summary>
internal interface FileMoverInterface
{
	/// <summary>
	/// Moves a file from a specific path to a new specific path.
	/// </summary>
	/// <param name="sourcePath">The source path of the file.</param>
	/// <param name="targetPath">The target path of the file.</param>
	void Move( string sourcePath, string targetPath );
}
