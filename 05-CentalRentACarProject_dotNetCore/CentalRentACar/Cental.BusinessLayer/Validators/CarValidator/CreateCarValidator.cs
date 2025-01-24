using Cental.DtoLayer.CarDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.CarValidator
{
    public class CreateCarValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("Model name is required");
            RuleFor(x => x.Transmission).NotEmpty().WithMessage("Transmission is required");
            RuleFor(x => x.FuelType).NotEmpty().WithMessage("FuelType is required");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("GearType is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Year is required");
            RuleFor(x => x.Kilometer).NotEmpty().WithMessage("Kilometer is required");
            RuleFor(x => x.SeatCount).NotEmpty().WithMessage("SeatCount is required");
        }
    }
}
