using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Configurations.Modules.MetaData;

/// <summary>
/// Represents creation date settings.
/// </summary>
[ JsonObject( MemberSerialization.OptIn ) ]
internal class CreationDateSettings:
	CreationDateSettingsInterface
{
	/// <summary>
	/// Stores the list of parsable formats.
	/// </summary>
	[ JsonProperty ]
	[ JsonConverter( typeof( ConcreteConverter<ParsableFormats> ) ) ]
	private readonly ParsableFormatsInterface parsableFormats = null!;

	/// <inheritdoc/>
	public virtual ParsableFormatsInterface ParsableFormats
	{
		get
		{
			return this.parsableFormats;
		}
	}

	/// <summary>
	/// Stores the returned format.
	/// </summary>
	[ JsonProperty ]
	private readonly string returnedFormat = null!;

	/// <inheritdoc/>
	public virtual string ReturnedFormat
	{
		get
		{
			return this.returnedFormat;
		}
	}
}
