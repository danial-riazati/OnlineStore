﻿using System;
using FluentValidation;

namespace OnlineStore.Application.Features.ProductFeatures.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(40);
            RuleFor(x => x.InventoryCount).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Discount).NotEmpty().GreaterThanOrEqualTo(0).LessThan(100);
        }
    }
}

