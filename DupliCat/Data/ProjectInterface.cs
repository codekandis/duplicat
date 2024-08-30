using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Data
{
	/// <summary>
	/// Represents the interface of any project.
	/// </summary>
	internal interface ProjectInterface:
		NotifyPropertyInterface
	{
		/// <summary>
		/// Gets / sets the path.
		/// </summary>
		string Path
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the MD5 sets of the project.
		/// </summary>
		Md5SetListInterface Md5Sets
		{
			get;
			set;
		}
	}
}
