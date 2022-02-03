using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator: AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
			RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
			RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı  boş geçilemez");
			RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı  boş geçilemez");
			RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("En az 4 karakter girmelisiniz");
			RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("50'den fazla karakter kullanamazsınız.");
		}
	}
}
