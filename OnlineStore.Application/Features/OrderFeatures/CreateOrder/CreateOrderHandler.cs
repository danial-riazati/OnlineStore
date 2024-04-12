using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Common;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByName(request.UserName, cancellationToken)
                ?? throw new BadRequestException("user is not valid");
            var product = await _productRepository.GetByTitle(request.ProductTitle, cancellationToken)
                ?? throw new BadRequestException("product is not valid");
            if (product.InventoryCount < 1)
                throw new BadRequestException("product inventory count is not valid");

            product.InventoryCount--;
            _productRepository.Update(product);

            var order = new Order { Buyer = user, Product = product };
            _orderRepository.Create(order);
            await _unitOfWork.SaveChanges(cancellationToken);
            RemoveFromMemCache(product);

            return _mapper.Map<CreateOrderResponse>(order);
        }
        private void RemoveFromMemCache(Product product)
        {
            var key = $"product_{product.Id}";
            _memoryCache.Remove(key);
        }
    }
}

