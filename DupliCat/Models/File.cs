using Newtonsoft.Json;
using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Models
{
	[JsonObject( MemberSerialization.OptIn )]
	internal class File:
		NotifyPropertyAbstract,
		IFile
	{
		[JsonProperty( PropertyName = "path" )]
		private string path;

		public virtual string Path
		{
			get
			{
				return this.path;
			}
			private set
			{
				this.PropertyChangingRaise();
				this.path = value;
				this.PropertyChangedRaise();
			}
		}

		[JsonProperty( PropertyName = "flagDeletion" )]
		private bool flagDeletion = false;

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

		public File( string path )
		{
			this.Path = path;
		}
	}
}
