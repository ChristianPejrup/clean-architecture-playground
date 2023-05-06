using Newtonsoft.Json;
using System.Text;

namespace Account.Client
{
    public abstract class BaseClient
    {      
        protected BaseClient(HttpClient client)
        {
            Client = client;
        }

        public HttpClient Client { get;}

        protected static StringContent GetJsonContentFromObject(object _object)
        {
            return new StringContent(JsonConvert.SerializeObject(_object), Encoding.UTF8, "application/json");
        }

        protected async Task<HttpResponseMessage> GetAndVerifyResponseAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            var responseMessage = await Client.SendAsync(requestMessage, cancellationToken);
            await responseMessage.VerifySuccessAsync();
            return responseMessage;
        }
    }
}