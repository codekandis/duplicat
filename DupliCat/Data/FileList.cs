using System.Collections.Generic;
using CodeKandis.DupliCat.Serialization.Json.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Data
{
	/// <summary>
	/// Represents a file list.
	/// </summary>
	[JsonArray( ItemConverterType = typeof( JsonFileListItemConverter ) )]
	internal class FileList:
		List<FileInterface>,
		FileListInterface;
}
