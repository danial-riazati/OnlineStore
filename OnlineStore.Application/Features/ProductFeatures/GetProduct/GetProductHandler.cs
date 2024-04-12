using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Common;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.ProductFeatures.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GetProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }


        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var key = $"product_{request.Id}";
            var cachedProduct = _memoryCache.Get<Product>(key);

            if (cachedProduct != null)
                return _mapper.Map<GetProductResponse>(cachedProduct);

            var product = await _productRepository.Get(request.Id, cancellationToken)
                ?? throw new BadRequestException("Product is not founded");

            SetInMemCache(product);
            return _mapper.Map<GetProductResponse>(product);


        }
        private void SetInMemCache(Product product)
        {
            var key = $"product_{product.Id}";
            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _memoryCache.Set(key, product, cacheOptions);
        }
    }
}

