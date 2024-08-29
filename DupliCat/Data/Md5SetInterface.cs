using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Data
{
	/// <summary>
	/// Represents the interface of any MD5 set.
	/// </summary>
	internal interface Md5SetInterface:
		NotifyPropertyInterface
	{
		/// <summary>
		/// Gets the checksum.
		/// </summary>
		string Checksum
		{
			get;
		}

		/// <summary>
		/// Gets the files matching the checksum.
		/// </summary>
		FileListInterface Files
		{
			get;
		}
	}
}
