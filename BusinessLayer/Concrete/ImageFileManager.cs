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
	public class ImageFileManager : IImageFileService
	{
		IImagesFileDal _ImagesFileDal;

		public ImageFileManager(IImagesFileDal ımagesFileDal)
		{
			_ImagesFileDal = ımagesFileDal;
		}

		public List<ImageFile> GetList()
		{
			return _ImagesFileDal.List();
		}
	}
}
