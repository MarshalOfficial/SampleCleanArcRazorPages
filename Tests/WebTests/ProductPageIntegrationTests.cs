using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;


namespace Tests.WebTests
{
    public class ProductPageIntegrationTests : IClassFixture<WebApplicationFactory<Web.Program>> // Use Program.cs
    {
        private readonly HttpClient _client;

        public ProductPageIntegrationTests(WebApplicationFactory<Web.Program> factory)
        {
            _client = factory.CreateClient(); // Create a client to interact with the test server
        }

        [Fact]
        public async Task Get_ProductIndex_ReturnsSuccess()
        {
            // Act
            var response = await _client.GetAsync("/Products"); // Request the Products page

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK); // Expect a 200 status code
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Contain("Products"); // Verify the expected content
        }
    }
}