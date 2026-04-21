using System.Net;
using System.Net.Http.Json;
using Xunit;
using EnergyMonitoringAPI.ViewModels;

namespace EnergyMonitoringAPI.Tests
{
    public class AuthControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Register_ReturnsHttpStatusCode200()
        {
            // Arrange
            var registerModel = new RegisterViewModel
            {
                Username = $"testuser_{Guid.NewGuid()}",
                Email = $"test_{Guid.NewGuid()}@test.com",
                Password = "Test123!"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/register", registerModel);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsHttpStatusCode200()
        {
            // Arrange - Primeiro registrar um usuário
            var username = $"logintest_{Guid.NewGuid()}";
            var password = "Test123!";
            
            var registerModel = new RegisterViewModel
            {
                Username = username,
                Email = $"{username}@test.com",
                Password = password
            };

            await _client.PostAsJsonAsync("/api/auth/register", registerModel);

            var loginModel = new LoginViewModel
            {
                Username = username,
                Password = password
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auth/login", loginModel);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}