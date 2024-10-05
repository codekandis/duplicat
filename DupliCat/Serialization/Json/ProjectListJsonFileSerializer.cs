using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Json;

/// <summary>
/// Represents a JSON project list serializer.
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
