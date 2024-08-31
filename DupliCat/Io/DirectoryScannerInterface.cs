using System.Collections.Generic;
using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents the interface of any directory scanner.
	/// </summary>
	internal interface DirectoryScannerInterface
	{
		/// <summary>
		/// Scans the directory.
		/// </summary>
		/// <param name="path">The path of the directory to scan.</param>
		/// <param name="patterns">The patterns to scan for.</param>
		/// <returns>The files of the directory.</returns>
		FileListInterface Scan( string path, IEnumerable<string> patterns );
	}
}
