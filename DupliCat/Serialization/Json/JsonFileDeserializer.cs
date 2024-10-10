using System.IO;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serialization.Json;

/// <summary>
/// Represents a serialized JSON file reader.
/// </summary>
/// <typeparam name="TData">The type of the deserialized data.</typeparam>
internal class JsonFileDeserializer<TData>:
	JsonDeserializerInterface<TData>
	where TData: class
{
	/// <summary>
	/// Stores the path of the serialized JSON file.
	/// </summary>
	private readonly string path;

	/// <summary>
	/// Constructor method.
	/// </summary>
	/// <param name="path">The path of the serialized JSON file.</param>
	public JsonFileDeserializer( string path )
	{
		this.path = path;
	}

	/// <inheritdoc/>
	public TData? Deserialize()
	{
		using Stream       stream       = new FileStream( this.path, FileMode.Open );
		using StreamReader streamReader = new StreamReader( stream );
		using JsonReader   jsonReader   = new JsonTextReader( streamReader );

		JsonSerializer jsonSerializer = new JsonSerializer();

		return jsonSerializer.Deserialize<TData>( jsonReader );
	}
}
