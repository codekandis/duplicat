using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Json
{
	/// <summary>
	/// Represents a MD5 set list JSON file serializer.
	/// </summary>
	internal class Md5SetListJsonFileSerializer:
		JsonFileSerializer<Md5SetListInterface>
	{
		/// <inheritdoc/>
		public Md5SetListJsonFileSerializer( string path )
			: base( path )
		{
		}
	}
}
