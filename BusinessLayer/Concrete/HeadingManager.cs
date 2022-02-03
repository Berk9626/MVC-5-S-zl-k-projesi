﻿using BusinessLayer.Abstract;
using DataAcessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class HeadingManager : IHeadingService
	{
		IHeadingDal _headingDal;
		public HeadingManager(IHeadingDal headingDal)
		{
			_headingDal = headingDal;
		}

		public Heading GetById(int id)
		{
			return _headingDal.Get(x=>x.HeadingId == id);
		}

		public List<Heading> GetList()
		{
			return _headingDal.List();
		}

		public List<Heading> GetListByWriter(int id)
		{
			return _headingDal.List(x => x.WriterId == id);
		}

		public void HeadingAddBL(Heading heading)
		{
			_headingDal.Insert(heading);
		}

		public void HeadingDelete(Heading heading)
		{
			//heading.HeadingStatus = false;
			_headingDal.Update(heading);
		}

		public void HeadingUpdate(Heading heading)
		{
			_headingDal.Update(heading);
		}
		
	}
}
