using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Application.DTOs.Validations
{
    public class StoreDTOValidator : AbstractValidator<StoreDTO>
    {
        public StoreDTOValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("CostPrice is required");

            RuleFor(x => x.Address)
            .NotEmpty()
            .NotNull()
            .WithMessage("CostPrice is required");
        }
    }
}
