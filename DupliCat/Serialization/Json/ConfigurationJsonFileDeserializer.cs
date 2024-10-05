using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Serialization.Json;

/// <summary>
/// Represents a configuration JSON deserializer.
/// </summary>
internal class ConfigurationJsonFileDeserializer:
	JsonFileDeserializer<ProjectList>
{
	/// <inheritdoc/>
	public ConfigurationJsonFileDeserializer( string path )
		: base( path )
	{
	}
}
