using System;
using EastIndia.Models;

namespace EastIndia.Helpers
{
	public class DbHelper
	{
		private static readonly Entities entities = new Entities();

		public static bool Insert<T>(T entity) where T : class
		{
			try
			{
				entities.Set<T>().Add(entity);
				entities.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				ErrorLogger.LogError(e);
				return false;
			}
		}

		public static bool Update<T>(Guid oldEntityId, T newEntityValues) where T : class
		{
			try
			{
				var oldEntity = entities.Set<T>().Find(oldEntityId);
				entities.Entry(oldEntity).CurrentValues.SetValues(newEntityValues);
				entities.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				ErrorLogger.LogError(e);
				return false;
			}
		}

		public static bool Remove<T>(Guid id) where T : class
		{
			try
			{
				var set = entities.Set<T>();
				var entity = set.Find(id);
				set.Remove(entity);
				entities.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				ErrorLogger.LogError(e);
				return false;
			}
		}
	}
}