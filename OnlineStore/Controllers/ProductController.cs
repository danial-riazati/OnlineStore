using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineStore.Application.Features.ProductFeatures.CreateProduct;
using OnlineStore.Application.Features.ProductFeatures.UpdateProductInventoryCount;
using OnlineStore.Application.Features.ProductFeatures.GetProduct;

namespace OnlineStore.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v1/product")]
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

    [HttpPost("UpdateInventoryCount")]
    public async Task<ActionResult<UpdateProductInventoryCountResponse>> UpdateProductInventoryCount(UpdateProductInventoryCountRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<UpdateProductInventoryCountResponse>> Get(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetProductRequest(Id: id), cancellationToken);
        return Ok(response);
    }
}

