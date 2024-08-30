using System;
using CodeKandis.DupliCat.Serialization.Json.Converters;
using Newtonsoft.Json;
using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Data
{
	/// <summary>
	/// Represents a project.
	/// </summary>
	[JsonObject( MemberSerialization.OptIn )]
	internal class Project:
		NotifyPropertyAbstract,
		ProjectInterface
	{
		/// <summary>
		/// Stores the path.
		/// </summary>
		[JsonProperty]
		private string path;

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
		/// Stores the MD5 sets.
		/// </summary>
		[JsonProperty]
		[JsonConverter( typeof( JsonMd5SetListConverter ) )]
		private Md5SetListInterface md5Sets;

		/// <inheritdoc/>
		public virtual Md5SetListInterface Md5Sets
		{
			get
			{
				return this.md5Sets;
			}
			private set
			{
				this.PropertyChangingRaise();
				this.md5Sets = value;
				this.PropertyChangedRaise();
			}
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="md5Sets">The MD5 sets.</param>
		public Project( string path, Md5SetListInterface md5Sets )
		{
			this.path = path;
			this.md5Sets = md5Sets;
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="path">The path.</param>
		public Project( string path )
		{
			this.path = path;
		}
	}
}
