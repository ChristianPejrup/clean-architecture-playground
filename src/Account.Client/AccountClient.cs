namespace Account.Client
{
    public class AccountClient : BaseClient, IAccountClient
    {
        public AccountClient(HttpClient client) : base(client)
        {
        }

        public async Task<AccountDto> Create(CreateAccount createAccount, CancellationToken cancellationToken = default)
        {
            var uri = $"/api/v1/accounts";

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = GetJsonContentFromObject(createAccount)
            };

            var responseMessage = await GetAndVerifyResponseAsync(requestMessage, cancellationToken);
            return await responseMessage.ReadAsAsync<AccountDto>();
        }

        public async Task Delete(Guid accountId, CancellationToken cancellationToken = default)
        {
            await Delete(accountId.ToString(), cancellationToken);
        }

        public async Task Delete(string accountIdOrEmail, CancellationToken cancellationToken = default)
        {
            var uri = $"/api/v1/accounts/{accountIdOrEmail}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            await GetAndVerifyResponseAsync(requestMessage, cancellationToken);
        }

        public async Task<AccountDto> Get(Guid accountId, CancellationToken cancellationToken = default)
        {
            return await Get(accountId.ToString(), cancellationToken);
        }

        public async Task<AccountDto> Get(string accountIdOrEmail, CancellationToken cancellationToken = default)
        {
            var uri = $"/api/v1/accounts/{accountIdOrEmail}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            
            var responseMessage = await GetAndVerifyResponseAsync(requestMessage, cancellationToken);
            return await responseMessage.ReadAsAsync<AccountDto>();
        }
        public async Task Update(Guid accountId, UpdateAccount updateAccount, CancellationToken cancellationToken = default)
        {
            var uri = $"/api/v1/accounts/{accountId}";

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = GetJsonContentFromObject(updateAccount)
            };

            var responseMessage = await GetAndVerifyResponseAsync(requestMessage, cancellationToken);
        }
    }
}
