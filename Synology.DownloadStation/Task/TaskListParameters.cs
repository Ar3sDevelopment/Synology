﻿using System;
using Synology.Classes;
using Synology.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Synology.DownloadStation.Task
{
	public class TaskListParameters : RequestParameters
	{
		public TaskDetailsType? Additional { get; set; }

		[Required]
		public int Offset { get; set; }

		[Required]
		public int Limit { get; set; }

		public TaskListParameters()
		{
			Additional = null;
			Offset = 0;
			Limit = -1;
		}

		public override QueryStringParameter[] Parameters()
		{
			return new[] {
				new QueryStringParameter("offset", Offset),
				new QueryStringParameter("limit", Limit),
				new QueryStringParameter("additional", Additional)
			};
		}
	}
}

