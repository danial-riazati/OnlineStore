using Moq;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Features.ProductFeatures.GetProduct;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Test;

public class GetProductHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IMemoryCache> _mockMemoryCache;
    private readonly GetProductHandler _handler;

    public GetProductHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockProductRepository = new Mock<IProductRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockMemoryCache = new Mock<IMemoryCache>();
        _handler = new GetProductHandler(_mockUnitOfWork.Object, _mockProductRepository.Object, _mockMapper.Object, _mockMemoryCache.Object);
    }
    [Fact]
    public async Task Handle_ShouldReturnCachedProduct_WhenProductIsCached()
    {
        var productId = new Guid("8913fa23-d474-4250-f619-08dc5af87e8f");
        var product = new Product
        {
            Id = productId,
            Title = "Laptop",
            InventoryCount = 23,
            Price = 100,
            Discount = 14,
            DateCreated = DateTimeOffset.MinValue
        };
        var cachedProductResponse = new GetProductResponse
        {
            Id = productId,
            Title = "Laptop",
            InventoryCount = 23,
            Price = 100,
            Discount = 14,
            DateCreated = DateTimeOffset.MinValue,
            FinalPrice = 86
        };
        var key = $"product_{productId}";
        object value = product;

        _mockMemoryCache.Setup(x => x.TryGetValue(key, out value)).Returns(true);
        _mockMapper.Setup(m => m.Map<GetProductResponse>(It.IsAny<Product>())).Returns(cachedProductResponse);

        var result = await _handler.Handle(new GetProductRequest(
          productId), CancellationToken.None);


        Assert.Equal(productId, result.Id);
        Assert.Equal("Laptop", result.Title);
        _mockProductRepository.Verify(r => r.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Never);
    }


}