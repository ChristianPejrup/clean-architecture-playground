using System.Data.Common;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Account.IntegrationTests
{

    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

            });

            builder.UseEnvironment("Development");
        }
    }
}