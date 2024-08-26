using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Json
{
	/// <summary>
	/// Represents a MD5 set list JSON file deserializer.
	/// </summary>
	internal class Md5SetListJsonFileDeserializer:
		JsonFileDeserializer<Md5SetList>
	{
		/// <inheritdoc/>
		public Md5SetListJsonFileDeserializer( string path )
			: base( path )
		{
		}
	}
}
