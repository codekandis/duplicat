namespace CodeKandis.DupliCat.Io.MetaData;

/// <summary>
/// Represents the interface of any creation date parser.
/// </summary>
internal interface CreationDateParserInterface
{
	/// <summary>
	/// Parses a creation date.
	/// </summary>
	/// <param name="creationDate">The creation date to parse.</param>
	/// <returns>The parsed creation date, `null` if failed.</returns>
	string? Parse( string creationDate );
}
