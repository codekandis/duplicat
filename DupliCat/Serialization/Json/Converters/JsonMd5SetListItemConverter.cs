using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Json.Converters;

/// <summary>
/// Represents a MD5 set list JSON item converter.
/// </summary>
internal class JsonMd5SetListItemConverter:
	JsonListItemConverter<Md5Set>;
