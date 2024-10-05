using System.IO;

namespace CodeKandis.DupliCat.Io.MetaData;

/// <summary>
/// Represents a meta data creation date extractor.
/// </summary>
internal class MetaDataCreationDateExtractor:
	MetaDataCreationDateExtractorInterface
{
	private readonly FileExtensionMetaDataCreationDateExtractorMappingsInterface fileExtensionMetaDataCreationDateExtractorMappings = new FileExtensionMetaDataCreationDateExtractorMappings();

	/// <summary>
	/// Extracts the creation date from the meta data.
	/// </summary>
	/// <param name="path">The path of the file to extract from.</param>
	/// <returns>The creation date from the meta data.</returns>
	public virtual string Extract( string path )
	{
		MetaDataCreationDateExtractorInterface metaDataCreationDateExtractor = this.fileExtensionMetaDataCreationDateExtractorMappings[
			Path.GetExtension( path )
		];

		return metaDataCreationDateExtractor?
			.Extract( path );
	}
}
