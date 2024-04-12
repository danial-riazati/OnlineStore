using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.ProductFeatures.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public CreateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            _productRepository.Create(product);
            await _unitOfWork.SaveChanges(cancellationToken);
            var response = _mapper.Map<CreateProductResponse>(product);
            return response;
        }
    }
}

