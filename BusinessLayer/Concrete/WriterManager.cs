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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public Writer CheckMailandPassword(Writer writer)
		{
			return _writerDal.Get(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
		}

		public Writer GetById(int id)
		{
			return _writerDal.Get(x=>x.WriterId == id);
		}

		public Writer GetByWriterMail(Writer writer)
		{
			return _writerDal.Get(x => x.WriterMail == writer.WriterMail);
		}

		public List<Writer> GetList()
		{
			return _writerDal.List();
		}

		public Writer GetWriterSession(string p)
		{
			
			return _writerDal.Get(x => x.WriterMail == p);
		}

		public void WriterAdd(Writer writer)
		{
			_writerDal.Insert(writer);
		}

		public void WriterDelete(Writer writer)
		{
			_writerDal.Delete(writer);
		}

		public void WriterUpdate(Writer writer)
		{
			_writerDal.Update(writer);
		}
	}
}
