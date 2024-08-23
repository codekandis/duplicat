namespace CodeKandis.DupliCat.Models
{
	internal interface Md5Interface
	{
		string Checksum
		{
			get;
		}

		FileList Files
		{
			get;
		}
	}
}
