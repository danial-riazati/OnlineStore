using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Repositories;

namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            return new CreateOrderResponse();
        }
    }
}

