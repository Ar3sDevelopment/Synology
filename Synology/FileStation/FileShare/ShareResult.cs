﻿using System;
using System.Dynamic;
using System.Configuration;

namespace Synology.FileStation.FileShare
{
	public class ShareResult
	{
		public string Path { get; set; }

		public string Name { get; set; }

		public ShareAdditionalResult Additional { get; set; }
	}
}

