using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents a file flagger.
/// </summary>
internal class FileFlagger:
	FileFlaggerInterface
{
	/// <inheritdoc/>
	public virtual void Flag( FileInterface file )
	{
		file.FlagDeletion = true;
	}
}
