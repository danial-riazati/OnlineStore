using System;
using MediatR;

namespace OnlineStore.Application.Features.ProductFeatures.GetProduct;

public sealed record GetProductRequest(Guid Id) : IRequest<GetProductResponse>;


