using Application.Interfaces;
using Application.Product.Queries.GetAllProducts;
using AutoMapper;
using Domain.Entities;
using Moq;


namespace Tests.Application
{
    public class GetAllProductsRequestHandlerTests
    {
        private readonly IMapper _mapper;

        public GetAllProductsRequestHandlerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Domain.Entities.Product>().ReverseMap();
            });

            _mapper = configuration.CreateMapper();
        }

        [Fact]
        public async Task Handle_ReturnsAllProducts()
        {
            // Arrange
            var productRepositoryMock = new Moq.Mock<IProductRepository>();
            var products = new List<Product>
            {
                new Product { Name = "Product 1", Price = 50m },
                new Product { Name = "Product 2", Price = 100m }
            };

            productRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            var handler = new GetAllProductRequestHandler(_mapper, productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(new GetAllProductsRequest(), CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}