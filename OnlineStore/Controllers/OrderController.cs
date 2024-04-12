using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineStore.Application.Features.OrderFeatures.CreateOrder;

namespace OnlineStore.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v1/order")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> Create(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}

