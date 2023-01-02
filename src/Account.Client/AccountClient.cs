namespace Account.Client
{
    public class AccountClient : BaseClient, IAccountClient
    {
        public AccountClient(HttpClient client) : base(client)
        {
        }

        public async Task<AccountDto> GetAccountAsync(Guid accountId, CancellationToken cancellationToken = default)
        {
            return await GetAccountAsync(accountId.ToString(), cancellationToken);
        }

        public async Task<AccountDto> GetAccountAsync(string accountId, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"/api/v1/accounts/{accountId}");

            return await GetAccountAsync(uri, cancellationToken);
        }

        public async Task<AccountDto> GetAccountAsync(Uri uri, CancellationToken cancellationToken = default)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var responseMessage = await GetAndVerifyResponseAsync(requestMessage, cancellationToken);
            return await responseMessage.ReadAsAsync<AccountDto>();
        }
    }
}
