using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Abstract
{
	public interface IRepository<T> where T: class, new()
	{
		List<T> List();
		void Insert(T p);
		T Get(Expression<Func<T, bool>> filter);
		void Update(T p);
		void Delete(T p);

		List<T> List(Expression<Func<T, bool>> fiter);
		//bu şartlı listeleme.Benim istediğim ifadedeki değerleri getirecek. Mesela sadece adı ali olan yazarları getir dersem.


	}
}
