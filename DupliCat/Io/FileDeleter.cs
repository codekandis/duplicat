using CodeKandis.DupliCat.Data;
using File = System.IO.File;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents a file deleter.
/// </summary>
internal class FileDeleter:
	FileDeleterInterface
{
	/// <inheritdoc/>
	public virtual void Delete( FileInterface file )
	{
		if ( File.Exists( file.Path ) )
		{
			File.Delete( file.Path );
		}
	}
}
