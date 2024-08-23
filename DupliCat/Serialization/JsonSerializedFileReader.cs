using System.IO;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serialization
{
	/// <summary>
	/// Represents a serialized JSON file reader.
	/// </summary>
	/// <typeparam name="TDeserialized">The type of the deserialized JSON data.</typeparam>
	internal class JsonSerializedFileReader<TDeserialized>:
		JsonSerializedReaderInterface<TDeserialized>
		where TDeserialized : class
	{
		/// <summary>
		/// Stores the path of the serialized JSON file.
		/// </summary>
		private readonly string path;

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="path">The path of the serialized JSON file.</param>
		public JsonSerializedFileReader( string path )
		{
			this.path = path;
		}

		/// <summary>
		/// Reads the serialized JSON file.
		/// </summary>
		/// <returns>The read deserialized JSON data.</returns>
		public TDeserialized Read()
		{
			using Stream stream = new FileStream( this.path, FileMode.Open );
			using StreamReader streamReader = new StreamReader( stream );
			using JsonReader jsonReader = new JsonTextReader( streamReader );

			JsonSerializer jsonSerializer = new JsonSerializer();

			return jsonSerializer.Deserialize<TDeserialized>( jsonReader );
		}
	}
}
