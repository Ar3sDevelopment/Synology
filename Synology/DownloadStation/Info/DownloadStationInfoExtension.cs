﻿using Synology.DownloadStation;
using Synology.DownloadStation.Info;

namespace Synology
{
	public static class DownloadStationInfoExtension
	{
		private static InfoRequest _info;

		public static InfoRequest Info(this DownloadStationApi api)
		{
			return _info ?? (_info = api.GetRequest<InfoRequest>());
		}
	}
}