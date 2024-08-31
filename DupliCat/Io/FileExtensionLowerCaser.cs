using System.IO;

namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents a file extension lower caser.
	/// </summary>
	internal class FileExtensionLowerCaser:
		FileExtensionLowerCaserInterface
	{
		/// <inheritdoc/>
		public virtual string LowerCase( string path )
		{
			string lowerCasedExtension = Path.GetExtension( path ).ToLower();
			string newPath = Path.ChangeExtension( path, lowerCasedExtension );

			File.Move( path, newPath );

			return newPath;
		}
	}
}
