using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		/// <inheritdoc/>
		public virtual FileListInterface Scan( string path, IEnumerable<string> patterns )
		{
			FileList files = new FileList();

			List<string> preparedPatterns = patterns
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
				IEnumerable<string> filePaths = Directory.EnumerateFiles( path, preparedPattern, SearchOption.AllDirectories );
				foreach ( string filePath in filePaths )
				{
					files.Add(
						new File
						{
							Path = filePath
						}
					);
				}
			}

			return files;
		}
	}
}
