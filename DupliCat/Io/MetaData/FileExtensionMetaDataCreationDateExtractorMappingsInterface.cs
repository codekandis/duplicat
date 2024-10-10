namespace CodeKandis.DupliCat.Io.MetaData;

/// <summary>
/// Represents the interface of any file extension meta data creation date extractor mappings.
/// </summary>
internal interface FileExtensionMetaDataCreationDateExtractorMappingsInterface
{
	/// <summary>
	/// Gets a file extension meta data creation date extractor by a specific file extension.
	/// </summary>
	/// <param name="fileExtension">The file extension of the meta data creation date extractor.</param>
	/// <return></return>
	MetaDataCreationDateExtractorInterface? this[ string fileExtension ]
	{
		get;
	}
}
