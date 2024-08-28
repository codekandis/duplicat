using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeKandis.DupliCat.Data;
using SharpKandis.Collections.Generic;
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
		/// Stores the patterns to scan for.
		/// </summary>
		private readonly IEnumerable<string> patterns;

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="path">The path of the directory to scan.</param>
		/// <param name="patterns">The patterns to scan for.</param>
		public DirectoryScanner( string path, IEnumerable<string> patterns )
		{
			this.path = path;
			this.patterns = patterns;
		}

		/// <inheritdoc/>
		public virtual FileListInterface Scan()
		{
			FileList files = new FileList();

			List<string> preparedPatterns = this
				.patterns
				.Where(
					pattern => string.Empty != pattern
				)
				.Select(
					pattern => pattern.ToLowerInvariant()
				)
				.Distinct()
				.ToList();

			if ( 0 == preparedPatterns.Count )
			{
				preparedPatterns.Add( "*.*" );
			}

			foreach ( string preparedPattern in preparedPatterns )
			{
				IEnumerable<string> filePaths = Directory.EnumerateFiles( this.path, preparedPattern, SearchOption.AllDirectories );
				foreach ( string filePath in filePaths )
				{
					files.Add(
						new File( filePath )
					);
				}
			}

			return files;
		}
	}
}
