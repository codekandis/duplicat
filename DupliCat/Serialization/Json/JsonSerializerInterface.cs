namespace CodeKandis.DupliCat.Serialization.Json;

/// <summary>
/// Represents the interface of any JSON serializer.
/// </summary>
/// <typeparam name="TData">The type of the data to serialize.</typeparam>
internal interface JsonSerializerInterface<in TData>
	where TData: class
{
	/// <summary>
	/// Serializes data.
	/// </summary>
	/// <param name="data">The data to serialize.</param>
	void Serialize( TData data );
}
