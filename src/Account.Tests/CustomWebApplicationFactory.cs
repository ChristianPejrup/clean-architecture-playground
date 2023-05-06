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

        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(sp => Substitute.For<IAccountReader>());
                services.AddSingleton(sp => Substitute.For<IAccountWriter>());
            });

            builder.UseEnvironment("Development");
        }
    }
}