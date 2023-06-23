using FluentValidation;

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
