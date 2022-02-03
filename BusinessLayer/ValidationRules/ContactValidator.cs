using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator: AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Username boş geçilemez");
			RuleFor(x => x.Subject).MinimumLength(2).WithMessage("En az 4 karakter girmelisiniz");
			RuleFor(x => x.UserName).MinimumLength(2).WithMessage("En az 4 karakter girmelisiniz");
			RuleFor(x => x.Subject).MaximumLength(50).WithMessage("50'den fazla karakter kullanamazsınız.");
		}
	}
}
