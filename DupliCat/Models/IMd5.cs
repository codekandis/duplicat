﻿using System.Collections.Generic;

namespace DupliCat.Models
{
	internal interface IMd5
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
