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
		/// <returns>The files of the directory.</returns>
		FileListInterface Scan();
	}
}
