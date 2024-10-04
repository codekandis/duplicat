using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace CodeKandis.DupliCat.Serialization.Json.Converters;

/// <summary>
/// Represents a JSON list item converter.
/// </summary>
/// <typeparam name="TListItem">The type of the converted list item.</typeparam>
internal class JsonListItemConverter<TListItem>:
	CustomCreationConverter<TListItem>
{
	/// <summary>
	/// Creates the deserialized list item.
	/// </summary>
	/// <param name="objectType">The determined type of the list item.</param>
	/// <returns>The deserialized list item.</returns>
	public override TListItem Create( Type objectType )
	{
		return ( TListItem ) FormatterServices.GetSafeUninitializedObject( typeof( TListItem ) );
	}
}
