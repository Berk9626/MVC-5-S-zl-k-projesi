using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IHeadingService
	{

		List<Heading> GetList();
		List<Heading> GetListByWriter(int id);
		void HeadingAddBL(Heading heading);
		Heading GetById(int id);
		void HeadingDelete(Heading heding);
		void HeadingUpdate(Heading heading);


	}
}
