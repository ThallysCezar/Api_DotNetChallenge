using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Application.DTOs.Validations
{
    public class StockItemDTOValidator : AbstractValidator<StockItemDTO>
    {
        public StockItemDTOValidator()
        {
            RuleFor(x => x.ProductId)
            .NotEmpty()
            .NotNull()
            .WithMessage("ProductId is required");

            RuleFor(x => x.Quantity)
            .NotEmpty()
            .NotNull()
            .WithMessage("Quantity is required");

            RuleFor(x => x.StoreId)
            .NotEmpty()
            .NotNull()
            .WithMessage("StoreId is required");

            RuleFor(x => x.CostPriceProduct)
            .NotEmpty()
            .NotNull()
            .WithMessage("CostPriceProduct is required");
        }
    }
}
