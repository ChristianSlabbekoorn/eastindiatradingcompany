using System;
using EastIndia.Models;

namespace EastIndia.Helpers
{
	public class ErrorLogger
	{
		public static void LogError(Exception e)
		{
			LogError(e.ToString());
		}

		public static void LogError(string message)
		{
			var log = new ErrorLog
			{
				ID = Guid.NewGuid(),
				Error = message,
				Timestamp = DateTime.Now
			};

			Console.WriteLine($"[{log.Timestamp}]Error: {log.Error}");
			DbHelper.Insert(log);
		}
	}
}