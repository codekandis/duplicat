namespace CodeKandis.DupliCat.Io;

/// <summary>
/// Represents the interface of any file path count extensioner.
/// </summary>
internal class FilePathCountExtensioner:
	FilePathCountExtensionerInterface
{
	/// <summary>
	/// Stores the registered file paths with their respective counters.
	/// </summary>
	private readonly RegisteredFilePathsInterface registeredFilePaths = new RegisteredFilePaths();

	/// <summary>
	/// Stores the padding length of the count extension.
	/// </summary>
	private readonly int paddingLength;

	/// <summary>
	/// Constructor method.
	/// </summary>
	/// <param name="paddingLength">The padding legnth of the count extension.</param>
	public FilePathCountExtensioner( int paddingLength )
	{
		this.paddingLength = paddingLength;
	}

	/// <inheritdoc/>
	public virtual string DetermineCountExtension( string path )
	{
		string countExtension = this
			.registeredFilePaths
			.Count( path )
			.ToString()
			.PadLeft( this.paddingLength, '0' );

		return countExtension;
	}
}
