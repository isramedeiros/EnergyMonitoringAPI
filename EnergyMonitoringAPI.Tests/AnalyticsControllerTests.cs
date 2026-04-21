using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xunit;
using EnergyMonitoringAPI.ViewModels;

namespace EnergyMonitoringAPI.Tests
{
    public class AnalyticsControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public AnalyticsControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        private async Task<string> GetAuthTokenAsync()
        {
            var registerModel = new RegisterViewModel
            {
                Username = $"testuser_{Guid.NewGuid()}",
                Email = $"test_{Guid.NewGuid()}@test.com",
                Password = "Test123!"
            };

            var registerResponse = await _client.PostAsJsonAsync("/api/auth/register", registerModel);
            
            if (registerResponse.IsSuccessStatusCode)
            {
                var tokenResponse = await registerResponse.Content.ReadFromJsonAsync<TokenResponseViewModel>();
                return tokenResponse?.Token ?? throw new Exception("Token não retornado");
            }

            throw new Exception("Falha ao obter token");
        }

        [Fact]
        public async Task GetConsumptionAnalysis_ReturnsHttpStatusCode200()
        {
            // Arrange
            var token = await GetAuthTokenAsync();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await _client.GetAsync("/api/Analytics/consumption");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}