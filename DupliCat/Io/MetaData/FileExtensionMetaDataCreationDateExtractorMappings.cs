using System.Collections.Generic;
using System.Linq;

namespace CodeKandis.DupliCat.Io.MetaData;

/// <summary>
/// Represents file extension meta data creation date extractor mappings.
/// </summary>
internal class FileExtensionMetaDataCreationDateExtractorMappings:
	FileExtensionMetaDataCreationDateExtractorMappingsInterface
{
	private readonly IDictionary<string, MetaDataCreationDateExtractorInterface> mappings = new Dictionary<string, MetaDataCreationDateExtractorInterface>
	{
		{ ".jpg", new JpegMetaDataCreationDateExtractor() },
		{ ".jpeg", new JpegMetaDataCreationDateExtractor() }
	};

	/// <inheritdoc/>
	public virtual MetaDataCreationDateExtractorInterface this[ string fileExtension ]
	{
		get
		{
			return this
				.mappings
				.Where(
					mapping =>
						fileExtension.ToLower() == mapping.Key
				)
				.Select(
					mapping =>
						mapping.Value
				)
				.DefaultIfEmpty( null )
				.First();
		}
	}
}
