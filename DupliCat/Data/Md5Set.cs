using CodeKandis.DupliCat.Serialization.Json.Converters;
using Newtonsoft.Json;
using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Data
{
	/// <summary>
	/// Represents a MD5 set.
	/// </summary>
	[JsonObject( MemberSerialization.OptIn )]
	internal class Md5Set:
		NotifyPropertyAbstract,
		Md5SetInterface
	{
		/// <summary>
		/// Stores the MD5 checksum.
		/// </summary>
		[JsonProperty]
		private string checksum = string.Empty;

		/// <inheritdoc/>
		public virtual string Checksum
		{
			get
			{
				return this.checksum;
			}
			set
			{
				this.PropertyChangingRaise();
				this.checksum = value;
				this.PropertyChangedRaise();
			}
		}

		/// <summary>
		/// Stores the files.
		/// </summary>
		[JsonProperty]
		[JsonConverter( typeof( JsonFileListConverter ) )]
		private FileListInterface files = new FileList();

		/// <inheritdoc/>
		public virtual FileListInterface Files
		{
			get
			{
				return this.files;
			}
			set
			{
				this.PropertyChangingRaise();
				this.files = value;
				this.PropertyChangedRaise();
			}
		}
	}
}
