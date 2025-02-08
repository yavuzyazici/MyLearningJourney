using Cental.DtoLayer.BookingDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators.BookingValidator
{
    public class UIBookingValidator : AbstractValidator<UIBookingDto>
    {
        public UIBookingValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage("Car can not be empty");
            RuleFor(x => x.PickUpPlace).NotEmpty().WithMessage("Pick Up Place can not be empty");
            RuleFor(x => x.PickUpDate).NotEmpty().WithMessage("Pick Up Date can not be empty");
            RuleFor(x => x.PickUpTime).NotEmpty().WithMessage("Pick Up Time can not be empty");
            RuleFor(x => x.DropOffPlace).NotEmpty().WithMessage("Drop Off Place can not be empty");
            RuleFor(x => x.DropOffDate).NotEmpty().WithMessage("Drop Off Date can not be empty");
            RuleFor(x => x.DropOffTime).NotEmpty().WithMessage("Drop Off Time can not be empty");
        }
    }
}
