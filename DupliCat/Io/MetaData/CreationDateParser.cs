using System;
using System.Globalization;

namespace CodeKandis.DupliCat.Io.MetaData;

/// <summary>
/// Represents the a creation date parser.
/// </summary>
internal class CreationDateParser:
	CreationDateParserInterface
{
	/// <summary>
	/// Represents the format of the parsed creation date.
	/// </summary>
	private const string PARSED_FORMAT = "yyyyMMdd-HHmmss";

	/// <summary>
	/// Stores the formats of the creation date to parse.
	/// </summary>
	private readonly string[] formats =
	[
		"yyyy:MM:dd HH:mm:ss",
		"yyyy:M:d H:m:s"
	];

	/// <inheritdoc/>
	public virtual string? Parse( string creationDate )
	{
		foreach ( string format in this.formats )
		{
			DateTime parsedCreationDate;
			bool     succeeded = DateTime.TryParseExact( creationDate, format, null, DateTimeStyles.None, out parsedCreationDate );

			if ( true == succeeded )
			{
				return parsedCreationDate.ToString( CreationDateParser.PARSED_FORMAT );
			}
		}

		return null;
	}
}
