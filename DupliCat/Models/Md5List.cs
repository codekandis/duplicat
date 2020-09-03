using System.Collections.Generic;
using DupliCat.Models.Converters;
using Newtonsoft.Json;

namespace DupliCat.Models
{
	[JsonArray( ItemConverterType = typeof( ListItemConverter<Md5> ) )]
	internal class Md5List:
		List<IMd5>
	{
	}
}
