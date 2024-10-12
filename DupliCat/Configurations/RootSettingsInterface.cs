using CodeKandis.DupliCat.Configurations.Modules;

namespace CodeKandis.DupliCat.Configurations;

/// <summary>
/// Represents the interface of any root settings.
/// </summary>
internal interface RootSettingsInterface
{
	/// <summary>
	/// Gets the modules settings.
	/// </summary>
	ModulesSettingsInterface Modules
	{
		get;
	}
}
