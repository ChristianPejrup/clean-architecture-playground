using Account.Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using NSubstitute;

namespace Account.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        public CustomWebApplicationFactory() 
            : base()
        {
            AccountReaderMock = Substitute.For<IAccountReader>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(AccountReaderMock);
            });

            builder.UseEnvironment("Development");
        }

        public IAccountReader AccountReaderMock { get; private set; }
    }
}