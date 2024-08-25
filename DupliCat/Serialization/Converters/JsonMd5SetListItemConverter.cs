using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Converters
{
	/// <summary>
	/// Represents a JSON MD5 set list item converter.
	/// </summary>
	internal class JsonMd5SetListItemConverter:
		JsonListItemConverter<Md5Set>;
}
