namespace Account.Client
{
    public abstract class BaseClient
    {      
        protected BaseClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get;}

        protected async Task<HttpResponseMessage> GetAndVerifyResponseAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            var responseMessage = await Client.SendAsync(requestMessage, cancellationToken);
            await responseMessage.VerifySuccessAsync();
            return responseMessage;
        }
    }
}