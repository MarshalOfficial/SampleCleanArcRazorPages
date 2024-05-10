using Application.Interfaces;
using Application.Product.Commands.Create;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace Tests.Application
{

    public class CreateProductCommandHandlerTests
    {
        private readonly IMapper _mapper;

        public CreateProductCommandHandlerTests()
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
        public async Task Handle_ValidRequest_CreatesProduct()
        {
            // Arrange
            var productRepositoryMock = new Moq.Mock<IProductRepository>();

            var createProductCommand = new CreateProductRequest { Name = "Test Product", Price = 100m };

            productRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            var handler = new CreateProductRequestHandler(productRepositoryMock.Object, _mapper);

            // Act
            var result = await handler.Handle(createProductCommand, CancellationToken.None);

            // Assert
            productRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}