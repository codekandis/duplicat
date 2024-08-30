using System;
using System.IO;

namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents a file extension lower caser.
	/// </summary>
	internal class FileExtensionLowerCaser:
		FileExtensionLowerCaserInterface
	{
		/// <summary>
		/// Stores the path of the file to lower case its extension.
		/// </summary>
		private readonly string path;

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="path">The path of the file to lower case its extension.</param>
		public FileExtensionLowerCaser( string path )
		{
			this.path = path;
		}

		/// <inheritdoc/>
		public virtual string LowerCase()
		{
			string lowerCasedExtension = Path.GetExtension( this.path ).ToLower();
			string newPath = Path.ChangeExtension( this.path, lowerCasedExtension );
			
			File.Move( this.path, newPath );

			return newPath;
		}
	}
}
