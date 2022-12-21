using Account.IntegrationTests;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Account.Tests
{
    public class AccountTests 
        : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public AccountTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task test()
        {
            // Arrange
            var expected = Guid.NewGuid();

            //Act
            var actual = await _client.GetAsync($"/api/v1/accounts/{expected}");

            //Assert
            Assert.True(actual.IsSuccessStatusCode);
        }
    }
}
