using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AdminManager : IAdminService
	{
		IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}

		public void AdminDelete(Admin admin)
		{
			_adminDal.Delete(admin);
		}

		public void AdminUpdate(Admin admin)
		{
			_adminDal.Update(admin);
		}

		public void AdminAddBL(Admin admin)
		{
			_adminDal.Insert(admin);
		}

		public Admin CheckUserandPassword(Admin admin)
		{
			return _adminDal.Get(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
		}

		public Admin GetById(int id)
		{
			return _adminDal.Get(x => x.AdminId == id);
		}

		public Admin GetByUserName(Admin admin)
		{
			return _adminDal.Get(x => x.AdminUserName == admin.AdminUserName);
		}

		public List<Admin> GetList()
		{
			return _adminDal.List();
		}

		public Admin GetRolesForUser(string username)
		{
			return _adminDal.Get(x => x.AdminUserName == username);

		}
	}
}
