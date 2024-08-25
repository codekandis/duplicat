using System;
using System.Collections.Generic;
using System.Linq;
using CodeKandis.DupliCat.Data;
using Newtonsoft.Json;

namespace CodeKandis.DupliCat.Serialization.Converters
{
	/// <summary>
	/// Represents a JSON file list converter.
	/// </summary>
	internal class JsonFileListConverter:
		ConcreteConverter<FileList>;
}
