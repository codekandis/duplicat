using System.Collections.Generic;
using CodeKandis.DupliCat.Serialization.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Models
{
	[JsonArray( ItemConverterType = typeof( JsonListItemConverter<File> ) )]
	internal class FileList:
		List<FileInterface>,
		FileListInterface
	{
	}
}
