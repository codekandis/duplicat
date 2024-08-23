namespace CodeKandis.DupliCat.Models
{
	internal interface FileInterface
	{
		string Path
		{
			get;
		}

		bool FlagDeletion
		{
			get;
		}
	}
}
