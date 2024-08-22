namespace CodeKandis.DupliCat.Serializers
{
	internal interface IJsonFileSerializer<TData>
	{
		void Serialize( TData data, string path );

		TData Deserialize( string path );
	}
}
