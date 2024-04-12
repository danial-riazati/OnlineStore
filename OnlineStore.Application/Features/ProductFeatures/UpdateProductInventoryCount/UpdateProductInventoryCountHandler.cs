using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Common;
using OnlineStore.Application.Features.ProductFeatures.CreateProduct;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.ProductFeatures.UpdateProductInventoryCount
{
    public class UpdateProductInventoryCountHandler : IRequestHandler<UpdateProductInventoryCountRequest, UpdateProductInventoryCountResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public UpdateProductInventoryCountHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<UpdateProductInventoryCountResponse> Handle(UpdateProductInventoryCountRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByTitle(request.Title, cancellationToken);

            if (product.InventoryCount >= request.InventoryCount)
                throw new BadRequestException("InventoryCount is less or equal to current one");

            product.InventoryCount = request.InventoryCount;

            _productRepository.Update(product);
            await _unitOfWork.SaveChanges(cancellationToken);
            RemoveFromMemCache(product);

            var response = _mapper.Map<UpdateProductInventoryCountResponse>(product);
            return response;
        }

        private void RemoveFromMemCache(Product product)
        {
            var key = $"product_{product.Id}";
            _memoryCache.Remove(key);
        }
    }
}

