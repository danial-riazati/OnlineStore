using System;
using FluentValidation;
using OnlineStore.Application.Features.ProductFeatures.UpdateProductInventoryCount;

namespace OnlineStore.Application.Features.ProductFeatures.UpdateProductInventoryCount
{
    public class UpdateProductInventoryCountValidator : AbstractValidator<UpdateProductInventoryCountRequest>
    {
        public UpdateProductInventoryCountValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(40);
            RuleFor(x => x.InventoryCount).NotEmpty().GreaterThan(0);
        }
    }
}

