using FluentValidation;
using GreatwideApp.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatwideApp.UI.Models.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewFormModel>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.ReviewerName).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Full Name is Required.")
                .MaximumLength(50);

            RuleFor(x => x.EmailAddress).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(x => x.Comments).Cascade(CascadeMode.StopOnFirstFailure)
                .MaximumLength(3000);
        }
    }
}
