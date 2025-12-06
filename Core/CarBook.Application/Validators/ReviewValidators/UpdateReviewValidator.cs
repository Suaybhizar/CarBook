using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri Adını Boş Geçmeyiniz.");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız.");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen Puan Değerini Boş Geçmeyiniz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen Yorum Değerini Boş Geçmeyiniz.");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen Yorum Kısmına en az 50 karakter veri girişi yapınız.");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen Yorum Kısmına en fazla 500 karakter veri girişi yapınız.");
            RuleFor(x=>x.CustomerImage).NotEmpty().WithMessage("Lütfen Müşteri Görselini Boş Geçmeyiniz.").MinimumLength(10).WithMessage("Lütfen en az 10 karakter uzunluğunda veri girişi yapınız.").MaximumLength(200).WithMessage("lütfen en fazla 200 karakter veri girişi yapınız.");

        }
    }
}
