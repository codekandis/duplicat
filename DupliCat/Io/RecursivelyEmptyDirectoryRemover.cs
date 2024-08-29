using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents a recursively empty directory remover.
	/// </summary>
	internal class RecursivelyEmptyDirectoryRemover:
		DirectoryRemoverInterface
	{
		/// <summary>
		/// Stores the path of the directory to remove.
		/// </summary>
		private readonly string path;

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="path">The path of the directory to scan.</param>
		public RecursivelyEmptyDirectoryRemover( string path )
		{
			this.path = path;
		}

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

			bool hasFileSystemEntries = Directory.EnumerateFileSystemEntries( rootDirectoryPath ).Any();
			if ( false == hasFileSystemEntries )
			{
				Directory.Delete( rootDirectoryPath );
			}
		}

		/// <summary>
		/// Removes the directory.
		/// </summary>
		public virtual void Remove()
		{
			this.RemoveEmptyDirectory( this.path );
		}
	}
}
