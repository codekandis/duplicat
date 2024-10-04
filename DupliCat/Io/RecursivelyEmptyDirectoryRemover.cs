using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents a recursively empty directory remover.
/// </summary>
internal class RecursivelyEmptyDirectoryRemover:
	DirectoryRemoverInterface
{
	/// <summary>
	/// Recursively removes an empty directory.
	/// </summary>
	/// <param name="rootDirectoryPath">The root directory path to iterate.</param>
	private void RemoveEmptyDirectory( string rootDirectoryPath )
	{
		IEnumerable<string> directoryPaths = Directory.EnumerateDirectories( rootDirectoryPath );
		foreach ( string directoryPath in directoryPaths )
		{
			this.RemoveEmptyDirectory( directoryPath );
		}

		bool hasFileSystemEntries = Directory
			.EnumerateFileSystemEntries( rootDirectoryPath )
			.Any();
		if ( false == hasFileSystemEntries )
		{
			Directory.Delete( rootDirectoryPath );
		}
	}

	/// <inheritdoc/>
	public virtual void Remove( string path )
	{
		this.RemoveEmptyDirectory( path );
	}
}
