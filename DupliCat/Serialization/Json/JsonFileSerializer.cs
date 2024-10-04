using System.IO;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serialization.Json;

/// <summary>
/// Represents a serialized JSON file reader.
/// </summary>
/// <typeparam name="TData">The type of the deserialized JSON data.</typeparam>
internal class JsonFileSerializer<TData>:
	JsonSerializerInterface<TData>
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
	public JsonFileSerializer( string path )
	{
		this.path = path;
	}

	/// <inheritdoc/>
	public void Serialize( TData data )
	{
		using Stream       stream       = new FileStream( this.path, FileMode.Create );
		using StreamWriter streamWriter = new StreamWriter( stream );
		using JsonWriter jsonWriter = new JsonTextWriter( streamWriter )
		{
			Formatting  = Formatting.Indented,
			Indentation = 1,
			IndentChar  = '\t'
		};

		JsonSerializer jsonSerializer = new JsonSerializer();

		jsonSerializer.Serialize( jsonWriter, data );
	}
}
