using System.Collections.Generic;
using DupliCat.Models.Converters;
using Newtonsoft.Json;
using SharpKandis.ComponentModel;

namespace DupliCat.Models
{
	[JsonObject( MemberSerialization.OptIn )]
	internal class Md5:
		NotifyPropertyAbstract,
		IMd5
	{
		[JsonProperty( PropertyName = "checksum" )]
		private string checksum;

		public virtual string Checksum
		{
			get
			{
				return this.checksum;
			}
			private set
			{
				this.PropertyChangingRaise();
				this.checksum = value;
				this.PropertyChangedRaise();
			}
		}

		[JsonProperty( PropertyName = "files" )]
		private FileList files;

		public virtual FileList Files
		{
			get
			{
				return this.files;
			}
			private set
			{
				this.PropertyChangingRaise();
				this.files = value;
				this.PropertyChangedRaise();
			}
		}
	}
}
