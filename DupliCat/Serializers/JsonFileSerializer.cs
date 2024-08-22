using System.IO;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serializers
{
	internal class JsonFileSerializer<TData>:
		IJsonFileSerializer<TData>
	{
		public virtual void Serialize( TData data, string path )
		{
			using ( FileStream stream = new FileStream( path, FileMode.Create ) )
			{
				using ( StreamWriter streamWriter = new StreamWriter( stream ) )
				{
					streamWriter.Write( JsonConvert.SerializeObject( data ) );
				}
			}
		}

		public virtual TData Deserialize( string path )
		{
			using ( FileStream stream = new FileStream( path, FileMode.Open ) )
			{
				using ( StreamReader streamReader = new StreamReader( stream ) )
				{
					TData deserializedData = JsonConvert.DeserializeObject<TData>( streamReader.ReadToEnd() );
					return deserializedData;
				}
			}
		}
	}
}
