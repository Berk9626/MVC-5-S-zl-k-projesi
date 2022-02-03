using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.EntityFramework
{
	public class EfMessageDal: GenericRepository<Message>, IMessageDal
	{
	}
}
