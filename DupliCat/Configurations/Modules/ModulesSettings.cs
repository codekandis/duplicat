using CodeKandis.DupliCat.Configurations.Modules.MetaData;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Configurations.Modules;

/// <summary>
/// Represents the interface of any modules settings.
/// </summary>
[ JsonObject( MemberSerialization.OptIn ) ]
internal class ModulesSettings:
	ModulesSettingsInterface
{
	/// <summary>
	/// Stores the metadata settings.
	/// </summary>
	[ JsonProperty ]
	[ JsonConverter( typeof( ConcreteConverter<MetaDataSettings> ) ) ]
	private readonly MetaDataSettingsInterface metaData = null!;

	/// <inheritdoc/>
	public virtual MetaDataSettingsInterface MetaData
	{
		get
		{
			return this.metaData;
		}
	}
}
