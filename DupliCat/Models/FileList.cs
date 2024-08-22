using System.Collections.Generic;
using CodeKandis.DupliCat.Models.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Models
{
	[JsonArray( ItemConverterType = typeof( ListItemConverter<File> ) )]
	internal interface IFileList:
		IList<IFile>
	{
	}
}
