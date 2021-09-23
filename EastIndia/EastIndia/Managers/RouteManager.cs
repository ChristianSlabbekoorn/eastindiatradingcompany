using System;
using System.Linq;

using EastIndia.Models;
using EastIndia.Helpers;
using EastIndia.Models.Dtos;

namespace EastIndia.Managers
{
	public class RouteManager
	{
		public static void AddRoute(string startName, string endName,
			byte segments, ConnectionType type)
		{
			var dbHelper = new DbHelper();
			var start = dbHelper.GetAll<Location>(x => x.Name == startName).Single();
			var end = dbHelper.GetAll<Location>(x => x.Name == endName).Single();

			var routeTo = new LocationDistance
			{
				ID = Guid.NewGuid(),
				EndLocationID = end.ID,
				StartLocationID = start.ID,
				ConnectionType = (byte)type,
				Segments = segments
			};

			var routeBack = new LocationDistance
			{
				ID = Guid.NewGuid(),
				EndLocationID = start.ID,
				StartLocationID = end.ID,
				ConnectionType = (byte)type,
				Segments = segments
			};

			dbHelper.Insert(routeTo);
			dbHelper.Insert(routeBack);
		}
	}
}