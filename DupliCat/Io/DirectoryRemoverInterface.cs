namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any directory remover.
/// </summary>
internal interface DirectoryRemoverInterface
{
	/// <summary>
	/// Removes the directory.
	/// </summary>
	/// <param name="path">The path of the directory to remove.</param>
	void Remove( string path );
}
