using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace EastIndia.Helpers
{
	public interface IDbHelper
	{
		T Get<T>(Guid id) where T : class;
		List<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class;
		bool Insert<T>(T entity) where T : class;
		bool Update<T>(Guid oldEntityId, T newEntityValues) where T : class;
		bool Remove<T>(Guid id) where T : class;
	}
}
