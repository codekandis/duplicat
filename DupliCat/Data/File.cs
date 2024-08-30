using Newtonsoft.Json;
using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Data
{
	/// <summary>
	/// Represents a file.
	/// </summary>
	[JsonObject( MemberSerialization.OptIn )]
	internal class File:
		NotifyPropertyAbstract,
		FileInterface
	{
		/// <summary>
		/// Stores the path of the file.
		/// </summary>
		[JsonProperty( PropertyName = "path" )]
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
		/// Stores if the file must be deleted.
		/// </summary>
		[JsonProperty( PropertyName = "flagDeletion" )]
		private bool flagDeletion;

		/// <inheritdoc/>
		public virtual bool FlagDeletion
		{
			get
			{
				return this.flagDeletion;
			}
			set
			{
				this.PropertyChangingRaise();
				this.flagDeletion = value;
				this.PropertyChangedRaise();
			}
		}
	}
}
