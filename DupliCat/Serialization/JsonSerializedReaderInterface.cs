namespace CodeKandis.DupliCat.Serialization
{
    /// <summary>
    /// Represents the interface of any serialized JSON reader.
    /// </summary>
    /// <typeparam name="TDeserialized">The type of the deserialized JSON data.</typeparam>
    internal interface JsonSerializedReaderInterface<out TDeserialized>
        where TDeserialized : class
    {
        /// <summary>
        /// Reads the JSON data.
        /// </summary>
        /// <returns>The read JSON data.</returns>
        TDeserialized Read();
    }
}
