using CodeKandis.DupliCat.Configurations;

namespace CodeKandis.DupliCat.Serialization.Json;

/// <summary>
/// Represents a JSON configuration deserializer.
/// </summary>
internal class ConfigurationJsonFileDeserializer:
	JsonFileDeserializer<Configuration>
{
	/// <inheritdoc/>
	public ConfigurationJsonFileDeserializer( string path )
		: base( path )
	{
	}
}
