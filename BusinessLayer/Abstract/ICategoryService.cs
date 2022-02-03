using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICategoryService
	{
		//methodu interfacede tanıt sonra sınıf tarafınd doldur
		List<Category> GetList();
		void CategoryAddBL(Category category);
		Category GetById(int id);
		void CategoryDelete(Category category);
		void CategoryUpdate(Category category);
		
		 
		

	}
}
