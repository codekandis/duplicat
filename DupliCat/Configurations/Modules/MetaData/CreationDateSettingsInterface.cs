namespace CodeKandis.DupliCat.Configurations.Modules.MetaData;

/// <summary>
/// Represents the interface of any creation date settings.
/// </summary>
internal interface CreationDateSettingsInterface
{
	/// <summary>
	/// Gets the list of parsable formats.
	/// </summary>
	ParsableFormatsInterface ParsableFormats
	{
		get;
	}

	/// <summary>
	/// Gets the returned format.
	/// </summary>
	string ReturnedFormat
	{
		get;
	}
}
