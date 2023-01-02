using Account.Client;
using Account.IntegrationTests;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
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
        public async Task GetAccount_ReturnsValidAccount()
        {
            // Arrange
            var expected = Guid.NewGuid();
            _factory.AccountReaderMock.GetAccount(expected).Returns(new Domain.Account { Id = expected });

            //Act
            var actual = await _accountClient.GetAccountAsync(expected);

            //Assert
            Assert.Equal(expected, actual.Id);
        }

        [Fact]
        public async Task GetAccount_EmptyId_ThrowsNotFoundException()
        {
            // Arrange
            var expected = Guid.NewGuid();
            _factory.AccountReaderMock.GetAccount(expected).ThrowsAsync(new Shared.Exceptions.NotFoundException(expected));

            //Act + Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _accountClient.GetAccountAsync(expected));
        }
    }
}
