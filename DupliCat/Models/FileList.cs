using System.Collections.Generic;
using DupliCat.Models.Converters;
using Newtonsoft.Json;

namespace DupliCat.Models
{
	[JsonArray( ItemConverterType = typeof( ListItemConverter<File> ) )]
	internal interface IFileList:
		IList<IFile>
	{
	}
}
