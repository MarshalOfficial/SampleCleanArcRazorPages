using Application.Product.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Pages.Products;

namespace Tests.WebTests
{
    public class CreateProductPageModelTests
    {
        [Fact]
        public async Task OnPostAsync_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var mediatorMock = new Moq.Mock<IMediator>();
            var createProductCommand = new CreateProductRequest { Name = "Test Product", Price = 100m };

            mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductRequest>(), default)).ReturnsAsync(0);

            var pageModel = new CreateModel(mediatorMock.Object);
            pageModel.Product = createProductCommand;

            // Act
            var result = await pageModel.OnPostAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result); // Check if it redirects
            var redirectResult = result as RedirectToPageResult;
            Assert.Equal("./Index", redirectResult.PageName); // Verify the redirect target
        }
    }
}