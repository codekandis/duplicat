using CodeKandis.DupliCat.Data;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serialization.Json.Converters;

/// <summary>
/// Represents a JSON MD5 set list converter.
/// </summary>
internal class JsonMd5SetListConverter:
	ConcreteConverter<Md5SetList>;
