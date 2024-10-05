using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Io;

/// <summary>Represents the interface of any file deleter.</summary>
internal interface FileDeleterInterface
{
	/// <summary>Deletes a file.</summary>
	/// <param name="file">The path of the file.</param>
	void Delete( FileInterface file );
}
