using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using OnlineStore.Controllers;
namespace OnlineStore.API.Test;

public class UnitTest1
{
    [Fact]
    public async Task GetProduct_Returns200_WhenProductExists()
    {
        // Arrange
        var mediatr = new Mock<IMediator>();
        //mediatr.Setup(m => m.Send(It.IsAny<GetProductQuery>(), It.IsAny<CancellationToken>()))
        //       .ReturnsAsync(new ProductDto());  

        var controller = new ProductController(mediatr.Object);

        var id = new Guid("8913fa23-d474-4250-f619-08dc5af87e8a");

        // Act
        var actionResult = await controller.Get(id, CancellationToken.None);

        // Assert
        var result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

}
