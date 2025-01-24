using Cental.DtoLayer.BrandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.BrandValidator
{
    public class CreateBrandValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Brand name can not be empty")
                .MinimumLength(3).WithMessage("Brand name can not be smaller than 3");
        }
    }
}
