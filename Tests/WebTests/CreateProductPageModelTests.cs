﻿using Application.Product.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductRequest>(), default)).ReturnsAsync(new Domain.Dtos.ResultWithId());

            var pageModel = new CreateModel(mediatorMock.Object);
            pageModel.Product = createProductCommand;

            // Act
            var result = await pageModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
        }
    }
}