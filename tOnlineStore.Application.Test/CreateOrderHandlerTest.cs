using Moq;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Application.Repositories;
using OnlineStore.Domain.Entities;
using OnlineStore.Application.Features.OrderFeatures.CreateOrder;

using OnlineStore.Application.Common;

namespace OnlineStore.Application.Test
{

    public class CreateOrderHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMemoryCache> _mockMemoryCache;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateOrderHandler _handler;

        public CreateOrderHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMemoryCache = new Mock<IMemoryCache>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateOrderHandler(_mockUnitOfWork.Object, _mockOrderRepository.Object, _mockProductRepository.Object, _mockUserRepository.Object, _mockMapper.Object, _mockMemoryCache.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowBadRequestException_WhenUserIsInvalid()
        {
            var request = new CreateOrderRequest { UserName = "invalidUser", ProductTitle = "ValidProduct" };
            _mockUserRepository.Setup(r => r.GetByName(request.UserName, It.IsAny<CancellationToken>()))!.ReturnsAsync(value: null);

            await Assert.ThrowsAsync<BadRequestException>(() => _handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowBadRequestException_WhenProductIsInvalid()
        {
            var request = new CreateOrderRequest { UserName = "ValidUser", ProductTitle = "invalidProduct" };
            var user = new User { Name = request.UserName };

            _mockUserRepository.Setup(r => r.GetByName(request.UserName, It.IsAny<CancellationToken>())).ReturnsAsync(user);
            _mockProductRepository.Setup(r => r.GetByTitle(request.ProductTitle, It.IsAny<CancellationToken>()))!.ReturnsAsync(value: null);

            await Assert.ThrowsAsync<BadRequestException>(() => _handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldCreateOrder_WhenUserAndProductAreValid()
        {
            var request = new CreateOrderRequest { UserName = "ValidUser", ProductTitle = "ValidProduct" };
            var user = new User { Name = request.UserName };
            var product = new Product { Id = new Guid(), Title = request.ProductTitle, InventoryCount = 10 };
            var order = new Order { Buyer = user, Product = product };

            _mockUserRepository.Setup(r => r.GetByName(request.UserName, It.IsAny<CancellationToken>())).ReturnsAsync(user);
            _mockProductRepository.Setup(r => r.GetByTitle(request.ProductTitle, It.IsAny<CancellationToken>())).ReturnsAsync(product);
            _mockMapper.Setup(m => m.Map<CreateOrderResponse>(It.IsAny<Order>())).Returns(new CreateOrderResponse());

            await _handler.Handle(request, CancellationToken.None);

            _mockOrderRepository.Verify(r => r.Create(It.IsAny<Order>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChanges(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowBadRequestException_WhenUserIsValidButProductInventoryCountIsZero()
        {
            var request = new CreateOrderRequest { UserName = "ValidUser", ProductTitle = "ValidProduct" };
            var user = new User { Name = request.UserName };
            var product = new Product { Id = new Guid(), Title = request.ProductTitle, InventoryCount = 0 };
            var order = new Order { Buyer = user, Product = product };

            _mockUserRepository.Setup(r => r.GetByName(request.UserName, It.IsAny<CancellationToken>())).ReturnsAsync(user);
            _mockProductRepository.Setup(r => r.GetByTitle(request.ProductTitle, It.IsAny<CancellationToken>())).ReturnsAsync(product);
            _mockMapper.Setup(m => m.Map<CreateOrderResponse>(It.IsAny<Order>())).Returns(new CreateOrderResponse());

            await Assert.ThrowsAsync<BadRequestException>(() => _handler.Handle(request, CancellationToken.None));

        }

    }
}

