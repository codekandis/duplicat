using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace CodeKandis.DupliCat.Models.Converters
{
	internal class ListItemConverter<TListItem>:
		CustomCreationConverter<TListItem>
	{
		public override TListItem Create( Type objectType )
		{
			return ( TListItem ) FormatterServices.GetSafeUninitializedObject( typeof( TListItem ) );
		}
	}
}
