using CodeKandis.DupliCat.Configurations.Modules.MetaData;

namespace CodeKandis.DupliCat.Configurations.Modules;

/// <summary>
/// Represents the interface of any modules settings.
/// </summary>
internal interface ModulesSettingsInterface
{
	/// <summary>
	/// Gets the metadata settings.
	/// </summary>
	MetaDataSettingsInterface MetaData
	{
		get;
	}
}
