using System.Collections.Generic;
using CodeKandis.DupliCat.Serialization.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Models
{
	[JsonArray( ItemConverterType = typeof(JsonListItemConverter<Md5> ) )]
	internal class Md5List:
		List<Md5Interface>,
		Md5ListInterface
	{
	}
}
