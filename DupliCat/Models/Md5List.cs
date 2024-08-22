using System.Collections.Generic;
using CodeKandis.DupliCat.Models.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Models
{
	[JsonArray( ItemConverterType = typeof( ListItemConverter<Md5> ) )]
	internal class Md5List:
		List<IMd5>
	{
	}
}
