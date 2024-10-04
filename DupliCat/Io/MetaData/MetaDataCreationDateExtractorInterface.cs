namespace CodeKandis.DupliCat.Io.MetaData;

/// <summary>
/// Represents the interface of any meta data creation date extractor.
/// </summary>
internal interface MetaDataCreationDateExtractorInterface
{
	/// <summary>
	/// Extracts the creation date from the meta data.
	/// </summary>
	/// <param name="path">The path of the file to extract from.</param>
	/// <returns>The creation date from the meta data.</returns>
	string Extract( string path );
}
