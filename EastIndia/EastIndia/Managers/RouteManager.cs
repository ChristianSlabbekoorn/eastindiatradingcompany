using System;
using System.Linq;

using EastIndia.Models;
using EastIndia.Helpers;

namespace EastIndia.Managers
{
	public class RouteManager
	{
		public static void AddRoute(string startName, string endName, byte segments)
		{
			var dbHelper = new DbHelper();
			var start = dbHelper.GetAll<Location>(x => x.Name == startName).Single();
			var end = dbHelper.GetAll<Location>(x => x.Name == endName).Single();

			var routeTo = new LocationDistance
			{
				ID = Guid.NewGuid(),
				EndLocationID = end.ID,
				StartLocationID = start.ID,
				ConnectionType = 0,
				Segments = segments
			};

			var routeBack = new LocationDistance
			{
				ID = Guid.NewGuid(),
				EndLocationID = start.ID,
				StartLocationID = end.ID,
				ConnectionType = 0,
				Segments = segments
			};

			dbHelper.Insert(routeTo);
			dbHelper.Insert(routeBack);
		}
	}
}