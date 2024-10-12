using System;
using System.Globalization;
using CodeKandis.DupliCat.Configurations.Modules.MetaData;

namespace CodeKandis.DupliCat.Io.MetaData;

/// <summary>
/// Represents the a creation date parser.
/// </summary>
/// <param name="settings">The settings of the creation date parser.</param>
internal class CreationDateParser( CreationDateSettingsInterface settings ):
	CreationDateParserInterface
{
	/// <inheritdoc/>
	public virtual string? Parse( string creationDate )
	{
		foreach ( string format in settings.ParsableFormats )
		{
			bool succeeded = DateTime.TryParseExact( creationDate, format, null, DateTimeStyles.None, out DateTime parsedCreationDate );

			if ( true == succeeded )
			{
				return parsedCreationDate.ToString( settings.ReturnedFormat );
			}
		}

		return null;
	}
}
