using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Configurations.Modules.MetaData;

/// <summary>
/// Represents the interface of any metadata settings.
/// </summary>
[ JsonObject( MemberSerialization.OptIn ) ]
internal class MetaDataSettings:
	MetaDataSettingsInterface
{
	/// <summary>
	/// Stores the creation date settings.
	/// </summary>
	[ JsonProperty ]
	[ JsonConverter( typeof( ConcreteConverter<CreationDateSettings> ) ) ]
	private readonly CreationDateSettingsInterface creationDate = null!;

	/// <inheritdoc/>
	public virtual CreationDateSettingsInterface CreationDate
	{
		get
		{
			return this.creationDate;
		}
	}
}
