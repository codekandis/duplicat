using System.Collections.Generic;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents registered paths.
/// </summary>
internal class RegisteredFilePaths:
	RegisteredFilePathsInterface
{
	/// <summary>
	/// Stores the internal list of registered file paths.
	/// </summary>
	private readonly IDictionary<string, int> internalList = new Dictionary<string, int>();

	/// <inheritdoc/>
	public virtual int Count( string filePath )
	{
		if ( false == this.internalList.ContainsKey( filePath ) )
		{
			this.internalList.Add( filePath, 0 );
		}

		return ++this.internalList[ filePath ];
	}
}
