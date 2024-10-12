namespace CodeKandis.DupliCat.Configurations;

/// <summary>
/// Represents the interface of any configuration.
/// </summary>
internal interface ConfigurationInterface
{
	/// <summary>
	/// Gets the root settings.
	/// </summary>
	RootSettingsInterface Root
	{
		get;
	}
}
