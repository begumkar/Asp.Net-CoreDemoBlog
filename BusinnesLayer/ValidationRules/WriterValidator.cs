using EntityLayer.Concreate;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer>

	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı Kısmı Boş Geçilemez");
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş Geçilemez");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilmez");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter giriniz");
		}

        
    }
}
