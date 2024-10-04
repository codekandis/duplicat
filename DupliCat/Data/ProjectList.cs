using System.Collections.Generic;
using CodeKandis.DupliCat.Serialization.Json.Converters;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Data;

/// <summary>
/// Represents a project list.
/// </summary>
[ JsonArray( ItemConverterType = typeof( JsonProjectListItemConverter ) ) ]
internal class ProjectList:
	List<ProjectInterface>,
	ProjectListInterface;
