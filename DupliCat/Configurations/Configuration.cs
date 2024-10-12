using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Configurations;

/// <summary>
/// Represents a configuration.
/// </summary>
[ JsonObject( MemberSerialization.OptIn ) ]
internal class Configuration:
	ConfigurationInterface
{
	/// <summary>
	/// Stores the root settings.
	/// </summary>
	[ JsonProperty( "CodeKandis.DupliCat" ) ]
	[ JsonConverter( typeof( ConcreteConverter<RootSettings> ) ) ]
	private RootSettingsInterface root = null!;

	/// <inheritdoc/>
	public virtual RootSettingsInterface Root
	{
		get
		{
			return this.root;
		}
	}
}
