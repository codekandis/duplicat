using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization
{
	/// <summary>
	/// Represents a serialized JSON file reader.
	/// </summary>
	internal class JsonSerializedMd5SetListFileReader:
		JsonSerializedFileReader<Md5SetList>
	{
		/// <inheritdoc/>
		public JsonSerializedMd5SetListFileReader( string path )
			: base( path )
		{
		}
	}
}
