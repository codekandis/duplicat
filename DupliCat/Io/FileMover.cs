using System.IO;

namespace CodeKandis.DupliCat.Io
{
	/// <summary>
	/// Represents a file mover.
	/// </summary>
	internal class FileMover:
		FileMoverInterface
	{
		/// <inheritdoc/>
		public virtual void Move( string sourcePath, string targetPath )
		{
			File.Move( sourcePath, targetPath );
		}
	}
}
