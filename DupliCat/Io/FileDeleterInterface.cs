using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any file deleter.
/// </summary>
internal interface FileDeleterInterface
{
	/// <summary>
	/// Deletes a file.
	/// </summary>
	/// <param name="file">The file to delete.</param>
	void Delete( FileInterface file );
}
