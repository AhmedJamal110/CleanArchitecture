using Application.Features.Properities.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class CreateProperityRequestValidation : AbstractValidator<CreateProperityRequest>
    {

        public CreateProperityRequestValidation()
        {
            RuleFor(R => R.properityRequest)
               .SetValidator(new NewProperityValidation());
        }

    }
}
