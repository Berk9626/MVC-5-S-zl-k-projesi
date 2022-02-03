using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Content //içerik
	{
		[Key]
		public int ContentId { get; set; }
		[StringLength(1000)]
		public string ContentValue { get; set; } //metinyazı
		public DateTime ContentDate { get; set; }



		public bool ContentStatus { get; set; }



		public int HeadingId { get; set; }
		public virtual Heading Heding { get; set; }

		public int? WriterId { get; set; } //?0buraya veri girişi yapmak zorunda değilim
		public virtual  Writer Writer { get; set; }

		//contentyazar
		//contentbaslik
	}
}
