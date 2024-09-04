using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Jpeg;

namespace CodeKandis.DupliCat.Io.MetaData
{
	/// <summary>
	/// Represents a JPEG meta data creation date extractor.
	/// </summary>
	internal class JpegMetaDataCreationDateExtractor:
		MetaDataCreationDateExtractorInterface
	{
		/// <inheritdoc/>
		public virtual string Extract( string path )
		{
			Tag tag = JpegMetadataReader
				.ReadMetadata( path )
				.SelectMany(
					directory =>
						directory.Tags
				)
				.FirstOrDefault(
					tag =>
						0x9003 == tag.Type
				);

			return tag?.Description;
		}
	}
}
