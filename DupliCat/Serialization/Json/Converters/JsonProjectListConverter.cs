using CodeKandis.DupliCat.Data;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serialization.Json.Converters;

/// <summary>
/// Represents a JSON project list converter.
/// </summary>
internal class JsonProjectListConverter:
	ConcreteConverter<ProjectList>;
