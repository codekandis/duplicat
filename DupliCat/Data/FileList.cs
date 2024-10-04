using System.Collections.Generic;
using CodeKandis.DupliCat.Serialization.Json.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Data;

/// <summary>
/// Represents a file list.
/// </summary>
[ JsonArray( ItemConverterType = typeof( JsonFileListItemConverter ) ) ]
internal class FileList:
	List<FileInterface>,
	FileListInterface
{
	/// <summary>
	/// Constructor method.
	/// </summary>
	public FileList()
	{
	}

	/// <summary>
	/// Constructor method.
	/// </summary>
	/// <param name="initialFiles">The initial files of the list.</param>
	public FileList( IEnumerable<FileInterface> initialFiles )
		: base( initialFiles )
	{
	}
}
