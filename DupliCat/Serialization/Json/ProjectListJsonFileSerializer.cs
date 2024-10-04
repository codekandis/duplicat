using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Json;

/// <summary>
/// Represents a MD5 set list JSON project serializer.
/// </summary>
internal class ProjectListJsonFileSerializer:
	JsonFileSerializer<ProjectListInterface>
{
	/// <inheritdoc/>
	public ProjectListJsonFileSerializer( string path )
		: base( path )
	{
	}
}
