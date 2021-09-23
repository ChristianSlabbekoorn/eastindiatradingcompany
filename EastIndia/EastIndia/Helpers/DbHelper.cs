using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using EastIndia.Models;

namespace EastIndia.Helpers
{
	public class DbHelper : IDbHelper
	{
		private static readonly Entities entities = new Entities();

		public T Get<T>(Guid id) where T : class
		{
			return entities.Set<T>().Find(id);
		}

		public List<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class
		{
			return entities.Set<T>().Where(predicate).ToList();
		}

		public bool Insert<T>(T entity) where T : class
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

		public bool Update<T>(Guid oldEntityId, T newEntityValues) where T : class
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

		public bool Remove<T>(Guid id) where T : class
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