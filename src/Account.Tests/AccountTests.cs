using Account.Client;
using Account.IntegrationTests;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Account.Tests
{
    public class AccountTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private readonly IAccountClient _accountClient;

        public AccountTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            _accountClient = new AccountClient(_client);
        }

        [Fact]
        public async Task GetAccount()
        {
            // Arrange
            var expected = Guid.NewGuid();

            //Act
            var actual = await _accountClient.GetAccountAsync(expected);

            //Assert
            Assert.Equal(expected, actual.Id);
        }
    }
}
