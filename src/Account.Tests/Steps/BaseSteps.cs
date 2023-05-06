using Account.Client;
using Account.Domain;
using Account.IntegrationTests;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using Xunit;

namespace Account.Tests.Steps
{
    public abstract class BaseSteps : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly ScenarioContext _scenarioContext;

        protected CustomWebApplicationFactory<Program> ApplicationFactory => _scenarioContext.Get<CustomWebApplicationFactory<Program>>();
        protected IAccountClient AccountClient => _scenarioContext.Get<AccountClient>();
        protected HttpClient HttpClient => _scenarioContext.Get<HttpClient>();


        
        protected IAccountReader AccountReaderMock => _scenarioContext.Get<IAccountReader>();
        protected IAccountWriter AccountWriterMock => _scenarioContext.Get<IAccountWriter>();


        protected BaseSteps(CustomWebApplicationFactory<Program> applicationFactory, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            if (applicationFactory != null && !Contains(applicationFactory))
            {              
                var httpClient = applicationFactory.CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
                
                var accountClient = new AccountClient(httpClient);

                Set(applicationFactory);
                Set(httpClient);
                Set(accountClient);

                Set(applicationFactory.Services.GetService<IAccountReader>());
                Set(applicationFactory.Services.GetService<IAccountWriter>());
            }
        }

        protected bool Contains<T>(T data)
        {
            return _scenarioContext.ContainsKey(GetDefaultKey<T>());
        }

        protected bool Contains(string key)
        {
            return _scenarioContext.ContainsKey(key);
        }

        protected T Get<T>(string? key = default)
        {
            if (key is not null && _scenarioContext.ContainsKey(key))
            {
                return _scenarioContext.Get<T>(key); 
            }

            return _scenarioContext.Get<T>();
        }

        protected void Set<T>(string key, T data)
        {
            _scenarioContext.Set(data, key);
        }

        protected void Set<T>(T data)
        {
            _scenarioContext.Set(data, GetDefaultKey<T>());
        }

        private string GetDefaultKey<T>()
        {
            return typeof(T).FullName;
        }
    }
}

