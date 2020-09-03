namespace DupliCat.Models
{
	internal interface IFile
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
