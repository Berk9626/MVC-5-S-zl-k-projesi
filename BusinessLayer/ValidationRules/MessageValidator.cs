using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class MessageValidator : AbstractValidator<Message>
	{
		public MessageValidator()
		{
			RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş geçilemez");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuy boş geçilemez");
			RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş geçilemez");

			RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girmelisiniz");
			RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter kullanın");
		}
	}
}
