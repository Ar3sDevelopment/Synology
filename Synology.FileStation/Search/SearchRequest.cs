﻿using System;
using Synology.Classes;
using Synology.Utilities;
using System.ComponentModel;

namespace Synology.FileStation.Search
{
	public class SearchRequest : SynologyRequest
	{
		public SearchRequest(SynologyConnection connection) : base(connection, "FileStation/file_find.cgi", "SYNO.FileStation.Search")
		{
		}

		public ResultData<StartSearchResult> Start(string folderPath, bool recursive = true, string pattern = null, string extension = null, FileType fileType = FileType.All, long? sizeFrom = null, long? sizeTo = null, long? mTimeFrom = null, long? mTimeTo = null, long? crTimeFrom = null, long? crTimeTo = null, long? aTimeFrom = null, long? aTimeTo = null, string owner = null, string group = null)
		{
			var additionalParams = new [] {
				new QueryStringParameter("folder_path", folderPath),
				new QueryStringParameter("recursive", recursive),
				new QueryStringParameter("pattern", pattern),
				new QueryStringParameter("extension", extension),
				new QueryStringParameter("filetype", fileType),
				new QueryStringParameter("size_from", sizeFrom),
				new QueryStringParameter("size_to", sizeTo),
				new QueryStringParameter("mtime_from", mTimeFrom),
				new QueryStringParameter("mtime_to", mTimeTo),
				new QueryStringParameter("crtime_from", crTimeFrom),
				new QueryStringParameter("crtime_to", crTimeTo),
				new QueryStringParameter("atime_from", aTimeFrom),
				new QueryStringParameter("atime_to", aTimeTo),
				new QueryStringParameter("owner", owner),
				new QueryStringParameter("group", group)
			};

			return GetData<StartSearchResult>("list_share", 1, additionalParams);
		}

		public ResultData<SearchListResult> List(string taskId, int offset = 0, int limit = 0, FileSortType sortBy = FileSortType.Name, ListSortDirection sortDirection = ListSortDirection.Ascending, string pattern = null, FileType fileType = FileType.All, FileDetailsType? additional = null)
		{
			var additionalParams = new [] {
				new QueryStringParameter("additional", additional),
				new QueryStringParameter("taskid", taskId),
				new QueryStringParameter("pattern", pattern),
				new QueryStringParameter("offset", offset),
				new QueryStringParameter("filetype", fileType),
				new QueryStringParameter("limit", limit),
				new QueryStringParameter("sort_by", sortBy),
				new QueryStringParameter("sort_direction", sortDirection)
			};

			return GetData<SearchListResult>("list", 1, additionalParams);
		}

		public ResultData Stop(string[] taskId)
		{
			var additionalParams = new [] {
				new QueryStringParameter("taskid", taskId)
			};

			return GetData("stop", 1, additionalParams);
		}

		public ResultData Clean(string[] taskId)
		{
			var additionalParams = new [] {
				new QueryStringParameter("taskid", taskId)
			};

			return GetData("clean", 1, additionalParams);
		}
	}
}

