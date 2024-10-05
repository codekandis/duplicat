using System.IO;
using CodeKandis.DupliCat.Data;
using File = System.IO.File;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents a file extension lower caser.
/// </summary>
internal class FileExtensionLowerCaser:
	FileExtensionLowerCaserInterface
{
	/// <inheritdoc/>
	public virtual void LowerCase( FileInterface file )
	{
		string lowerCasedExtension = Path
			.GetExtension( file.Path )
			.ToLower();
		string newPath = Path.ChangeExtension( file.Path, lowerCasedExtension );

		File.Move( file.Path, newPath );

		file.Path = newPath;
	}
}
