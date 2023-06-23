using FluentValidation;

namespace ProjectAPI.Application.DTOs.Validations
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Name is required");

            RuleFor(x => x.CostPrice)
            .NotEmpty()
            .NotNull()
            .WithMessage("CostPrice is required");
        } 
    }
}
