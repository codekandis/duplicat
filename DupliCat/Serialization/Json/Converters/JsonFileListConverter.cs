using CodeKandis.DupliCat.Data;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serialization.Json.Converters;

/// <summary>
/// Represents a JSON file list converter.
/// </summary>
internal class JsonFileListConverter:
	ConcreteConverter<FileList>;
