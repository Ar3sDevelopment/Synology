﻿using System;
using Synology.Classes;
using Synology.Utilities;

namespace Synology.Api
{
	public class AuthRequest : SynologyRequest
	{
		private string _sessionNumber;

		internal AuthRequest(SynologyConnection connection) : base(connection, "auth.cgi", "SYNO.API.Auth")
		{
			var rand = new Random((int)DateTime.Now.Ticks);
			_sessionNumber = $"session{rand.Next()}";
		}

		public ResultData<LoginResult> Login(string username, string password, string otpCode = null, string sessionName = null)
		{
			_sessionNumber = sessionName ?? _sessionNumber;

			var parameters = new[] {
				new QueryStringParameter("otp_code", otpCode),
				new QueryStringParameter("account", username),
				new QueryStringParameter("passwd", password),
				new QueryStringParameter("session", _sessionNumber),
				new QueryStringParameter("format", "sid")
			};

			var url = GetApiUrl("login", 4, parameters);
			var result = Connection.GetDataFromUrl<LoginResult>(url);

			if (result.Success && !string.IsNullOrWhiteSpace(result.Data?.Sid))
			{
				Connection.Sid = result.Data.Sid;
			}

			return result;
		}

		public ResultData Logout()
		{
			var parameters = new[] {
				new QueryStringParameter("session", _sessionNumber),
			};

			var url = GetApiUrl("logout", 1, parameters);
			var result = Connection.GetDataFromUrl(url);

			if (result.Success)
			{
				Connection.Sid = null;
			}

			return result;
		}
	}
}