using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.Infrastructure
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async Task AddAsync_ProductIsAdded()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductDb")
                .Options;

            using (var dbContext = new AppDbContext(options))
            {
                var repository = new ProductRepository(dbContext);
                var product = new Product { Name = "New Product", Price = 150m };

                // Act
                await repository.CreateAsync(product);

                // Assert
                var fetchedProduct = await dbContext.Products.FindAsync(product.Id);
                Assert.NotNull(fetchedProduct);
                Assert.Equal("New Product", fetchedProduct.Name);
                Assert.Equal(150m, fetchedProduct.Price);
            }
        }
    }
}