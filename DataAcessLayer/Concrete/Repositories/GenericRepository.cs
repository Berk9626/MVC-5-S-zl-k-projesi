using DataAcessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Concrete.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class, new()
	{
		Context c = new Context();
		DbSet<T> _object; //t değerine karşılık gelen sınıfa ctor bulacağız ki objemize değer ataması yapalım.

		public GenericRepository()
		{
			_object = c.Set<T>(); //contexte bağlı olarak gönderilen T değeri
		}

		public void Delete(T p)
		{
			var deletedentity = c.Entry(p);
			deletedentity.State = EntityState.Deleted;
			//_object.Remove(p);
			c.SaveChanges();
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			return _object.SingleOrDefault(filter);//sadece 1 değer
		}

		public void Insert(T p)
		{
			var addedEntity = c.Entry(p);
			addedEntity.State = EntityState.Added;
			//_object.Add(p);
			c.SaveChanges();
		}

		public List<T> List()
		{
			return _object.ToList();
			
		}

		public List<T> List(Expression<Func<T, bool>> filter)
		{
			return _object.Where(filter).ToList();
		}

		public void Update(T p)
		{
			var updatedentity = c.Entry(p);
			updatedentity.State = EntityState.Modified;
			c.SaveChanges();
		}
	}
}
