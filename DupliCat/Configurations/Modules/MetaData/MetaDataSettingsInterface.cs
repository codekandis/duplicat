namespace CodeKandis.DupliCat.Configurations.Modules.MetaData;

/// <summary>
/// Represents the interface of any metadata settings.
/// </summary>
internal interface MetaDataSettingsInterface
{
	/// <summary>
	/// Gets the creation date settings.
	/// </summary>
	CreationDateSettingsInterface CreationDate
	{
		get;
	}
}
