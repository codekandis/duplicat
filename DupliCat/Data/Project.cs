using CodeKandis.DupliCat.Serialization.Json.Converters;
using Newtonsoft.Json;
using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Data;

/// <summary>
/// Represents a project.
/// </summary>
[ JsonObject( MemberSerialization.OptIn ) ]
internal class Project:
	NotifyPropertyAbstract,
	ProjectInterface
{
	/// <summary>
	/// Stores the notes.
	/// </summary>
	[ JsonProperty ]
	private string notes;

	/// <inheritdoc/>
	public virtual string Notes
	{
		get
		{
			return this.notes;
		}

		set
		{
			this.PropertyChangingRaise();
			this.notes = value;
			this.PropertyChangedRaise();
		}
	}

	/// <summary>
	/// Stores the path.
	/// </summary>
	[ JsonProperty ]
	private string path = string.Empty;

	/// <inheritdoc/>
	public virtual string Path
	{
		get
		{
			return this.path;
		}

		set
		{
			this.PropertyChangingRaise();
			this.path = value;
			this.PropertyChangedRaise();
		}
	}

	/// <summary>
	/// Stores the patterns.
	/// </summary>
	[ JsonProperty ]
	private string patterns = string.Empty;

	/// <inheritdoc/>
	public virtual string Patterns
	{
		get
		{
			return this.patterns;
		}

		set
		{
			this.PropertyChangingRaise();
			this.patterns = value;
			this.PropertyChangedRaise();
		}
	}

	/// <summary>
	/// Stores the MD5 sets.
	/// </summary>
	[ JsonProperty ]
	[ JsonConverter( typeof( JsonMd5SetListConverter ) ) ]
	private Md5SetListInterface md5Sets = new Md5SetList();

	/// <inheritdoc/>
	public virtual Md5SetListInterface Md5Sets
	{
		get
		{
			return this.md5Sets;
		}

		set
		{
			this.PropertyChangingRaise();
			this.md5Sets = value;
			this.PropertyChangedRaise();
		}
	}
}
