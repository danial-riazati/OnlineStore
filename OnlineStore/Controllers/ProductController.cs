using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineStore.Application.Features.ProductFeatures.CreateProduct;

namespace OnlineStore.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}

