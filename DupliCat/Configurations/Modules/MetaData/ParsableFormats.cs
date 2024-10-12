using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Configurations.Modules.MetaData;

/// <summary>
/// Represents a list of parsable formats.
/// </summary>
internal class ParsableFormats:
	List<string>,
	ParsableFormatsInterface;
