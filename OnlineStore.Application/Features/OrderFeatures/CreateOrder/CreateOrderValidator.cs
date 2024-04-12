using System;
using FluentValidation;
namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.ProductTitle).NotEmpty().MaximumLength(40);
            RuleFor(x => x.UserName).NotEmpty();
        }
    }
}

