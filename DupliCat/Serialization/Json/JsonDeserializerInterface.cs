namespace CodeKandis.DupliCat.Serialization.Json
{
	/// <summary>
	/// Represents the interface of any JSON deserializer.
	/// </summary>
	/// <typeparam name="TData">The type of the deserialized data.</typeparam>
	internal interface JsonDeserializerInterface<out TData>
		where TData : class
	{
		/// <summary>
		/// Deserializes the JSON data.
		/// </summary>
		/// <returns>The deserialized data.</returns>
		TData Deserialize();
	}
}
