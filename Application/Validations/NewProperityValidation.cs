using Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class NewProperityValidation : AbstractValidator<NewProperityRequest>
    {

        public NewProperityValidation()
        {

            RuleFor(R => R.Name)
              .NotEmpty().WithMessage("properity name is required")
              .MaximumLength(15).WithMessage("properity maximum length is 15");
        }

    }
}
