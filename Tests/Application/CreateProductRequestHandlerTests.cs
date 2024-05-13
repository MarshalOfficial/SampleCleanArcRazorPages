using Application.Interfaces;
using Application.Product.Commands.Create;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace Tests.Application
{

    public class CreateProductRequestHandlerTests
    {
        private readonly IMapper _mapper;

        public CreateProductRequestHandlerTests()
        {
            // Set up AutoMapper with necessary configurations
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateProductRequest, Product>();
                // Add other necessary mappings
            });

            _mapper = configuration.CreateMapper(); // Create IMapper instance with configurations
        }

        [Fact]
        public async Task Handle_Request_CreatesProduct()
        {
            // Arrange
            var productRepositoryMock = new Moq.Mock<IProductRepository>();

            var createProductCommand = new CreateProductRequest { Name = "Test Product", Price = 100m };

            productRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var handler = new CreateProductRequestHandler(productRepositoryMock.Object, _mapper);

            // Act and Assert when application layer throw exceptions
            //var exception = await Assert.ThrowsAsync<BadRequestException>(() =>
            //    handler.Handle(createProductCommand, CancellationToken.None));

            //Assert.Contains("Something went wrong.", exception.Message);
            //Assert.Contains("The product Already exists.", exception.Errors.Values.FirstOrDefault());

            var result = await handler.Handle(createProductCommand, CancellationToken.None);

            Assert.Equal(false, result.Succeed);
            Assert.Contains("The product Already exists.", result.Errors.Values.FirstOrDefault());
        }

        [Fact]
        public async Task Handle_Request_EmptyName_CreatesProduct()
        {
            // Arrange
            var productRepositoryMock = new Moq.Mock<IProductRepository>();

            var createProductCommand = new CreateProductRequest { Name = string.Empty, Price = 100m };

            productRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var handler = new CreateProductRequestHandler(productRepositoryMock.Object, _mapper);


            // Act and Assert
            var result = await handler.Handle(createProductCommand, CancellationToken.None);

            Assert.Equal(false, result.Succeed);
            Assert.Contains("Product name is required.", result.Errors.Values.FirstOrDefault());
        }

        [Fact]
        public async Task Handle_Request_NegativePrice_CreatesProduct()
        {
            // Arrange
            var productRepositoryMock = new Moq.Mock<IProductRepository>();

            var createProductCommand = new CreateProductRequest { Name = "Laptop", Price = -100 };

            productRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var handler = new CreateProductRequestHandler(productRepositoryMock.Object, _mapper);


            // Act and Assert
            var result = await handler.Handle(createProductCommand, CancellationToken.None);

            Assert.Equal(false, result.Succeed);
            Assert.Contains("Product price must be greater than zero.", result.Errors.Values.FirstOrDefault());
        }

        [Fact]
        public async Task Handle_Request_OverPrice_CreatesProduct()
        {
            // Arrange
            var productRepositoryMock = new Moq.Mock<IProductRepository>();

            var createProductCommand = new CreateProductRequest { Name = "Laptop", Price = 100001 };

            productRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var handler = new CreateProductRequestHandler(productRepositoryMock.Object, _mapper);


            // Act and Assert
            var result = await handler.Handle(createProductCommand, CancellationToken.None);


            Assert.Equal(false, result.Succeed);
            Assert.Contains("Product price must be less than $100K.", result.Errors.Values.FirstOrDefault());
        }
    }
}