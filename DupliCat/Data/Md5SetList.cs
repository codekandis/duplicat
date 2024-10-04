using System.Collections.Generic;
using CodeKandis.DupliCat.Serialization.Json.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Data;

/// <summary>
/// Represents a MD5 set list.
/// </summary>
[ JsonArray( ItemConverterType = typeof( JsonMd5SetListItemConverter ) ) ]
internal class Md5SetList:
	List<Md5SetInterface>,
	Md5SetListInterface;
