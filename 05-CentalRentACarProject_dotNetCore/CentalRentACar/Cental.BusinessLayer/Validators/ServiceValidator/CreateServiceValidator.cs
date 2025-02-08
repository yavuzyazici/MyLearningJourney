using Cental.DtoLayer.ServiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.ServiceValidator
{
    public class CreateServiceValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon can not be empty");
        }
    }
}
