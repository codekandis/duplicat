using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any file flagger.
/// </summary>
internal interface FileFlaggerInterface
{
	/// <summary>
	/// Flags a file for deletion.
	/// </summary>
	/// <param name="file">The file.</param>
	void Flag( FileInterface file );
}
