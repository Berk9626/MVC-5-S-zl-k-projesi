using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		[StringLength(50)]
		public string CategoryName { get; set; }
		[StringLength(200)]
		public string CategoryDescription { get; set; }
		public bool CategoryStatus { get; set; } //bool, ilişkili tablolarda silme işi kullanmayacağız, gizleyeceğiz.Aktif ya da pasif.Pasif haline getirirsem ana sayfada görünmez
												 // çünkü bir category silersem altındaki headingler de dolayısıyla contentler de silinecek

		public ICollection<Heading> Headings { get; set; }

	}
}
