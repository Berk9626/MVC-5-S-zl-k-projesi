using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator: AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
			RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş geçilemez");
			RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 4 karakter girmelisiniz");
			RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("20'den fazla karakter kullanamazsınız.");
			RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Kategori 20 karakterden az olamaz");

		}
	}
}
