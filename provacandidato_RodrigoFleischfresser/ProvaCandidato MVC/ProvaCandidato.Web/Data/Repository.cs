using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProvaCandidato.Data
{
	public class Repository<T> where T : class
	{
		ContextoPrincipal context = new ContextoPrincipal();

		public void Insert(T obj)
		{
			context.Set<T>().Add(obj);
			context.SaveChanges();
		}

		public void Update(T obj)
		{
			context.Entry(obj).State = EntityState.Modified;
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			context.Set<T>().Remove(GetById(id));
			context.SaveChanges();
		}

		public List<T> GetAll()
		{
			return context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return context.Set<T>().Find(id);
		}

		public T GetByCondition(Expression<Func<T, bool>> expression)
		{
			return context.Set<T>().FirstOrDefault(expression);
		}
	}
}