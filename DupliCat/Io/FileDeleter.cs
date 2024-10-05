using System.IO;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents a file deleter.
/// </summary>
internal class FileDeleter:
	FileDeleterInterface
{
	/// <inheritdoc/>
	public virtual void Delete( string path )
	{
		File.Delete( path );
	}
}
