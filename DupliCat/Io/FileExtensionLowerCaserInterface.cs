using CodeKandis.DupliCat.Data;

namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any file extension lower caser.
/// </summary>
internal interface FileExtensionLowerCaserInterface
{
	/// <summary>
	/// Lower cases the file extension.
	/// </summary>
	/// <param name="file">The file to lower case its extension.</param>
	void LowerCase( FileInterface file );
}
