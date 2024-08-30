using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Json
{
	/// <summary>
	/// Represents a MD5 set list JSON project deserializer.
	/// </summary>
	internal class ProjectListJsonFileDeserializer:
		JsonFileDeserializer<ProjectList>
	{
		/// <inheritdoc/>
		public ProjectListJsonFileDeserializer( string path )
			: base( path )
		{
		}
	}
}
