using System;
using FluentValidation;

namespace OnlineStore.Application.Features.ProductFeatures.GetProduct
{
    public class GetProductValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

