using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Data
{
	/// <summary>
	/// Represents the interface of any file.
	/// </summary>
	internal interface FileInterface:
		NotifyPropertyInterface
	{
		/// <summary>
		/// Gets the path of the file.
		/// </summary>
		string Path
		{
			get;
		}

		/// <summary>
		/// Gets / sets  the flag if the file must be deleted.
		/// </summary>
		bool FlagDeletion
		{
			get;
			set;
		}
	}
}
