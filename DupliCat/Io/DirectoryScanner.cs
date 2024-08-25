using System.Collections.Generic;
using System.IO;
using CodeKandis.DupliCat.Data;
using File = CodeKandis.DupliCat.Data.File;

namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents a directory scanner.
	/// </summary>
	internal class DirectoryScanner:
		DirectoryScannerInterface
	{
		/// <summary>
		/// Stores the path of the directory to scan.
		/// </summary>
		private readonly string path;

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="path">The path of the directory to scan.</param>
		public DirectoryScanner( string path )
		{
			this.path = path;
		}

		/// <inheritdoc/>
		public virtual FileListInterface Scan()
		{
			FileList files = new FileList();

			IEnumerable<string> filePaths = Directory.EnumerateFiles( this.path, "*.*", SearchOption.AllDirectories );
			foreach ( string filePath in filePaths )
			{
				files.Add(
					new File( filePath )
				);
			}

			return files;
		}
	}
}
