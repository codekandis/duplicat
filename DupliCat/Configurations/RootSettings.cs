using CodeKandis.DupliCat.Configurations.Modules;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Configurations;

/// <summary>
/// Represents the root settings.
/// </summary>
[ JsonObject( MemberSerialization.OptIn ) ]
internal class RootSettings:
	RootSettingsInterface
{
	/// <summary>
	/// Stores the modules settings.
	/// </summary>
	[ JsonProperty ]
	[ JsonConverter( typeof( ConcreteConverter<ModulesSettings> ) ) ]
	private readonly ModulesSettingsInterface modules = null!;

	/// <inheritdoc/>
	public virtual ModulesSettingsInterface Modules
	{
		get
		{
			return this.modules;
		}
	}
}
