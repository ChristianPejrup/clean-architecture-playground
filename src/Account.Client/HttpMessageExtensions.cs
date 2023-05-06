using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;

namespace Account.Client
{
    internal static class HttpMessageExtensions
    {
        public static void SetBearerToken(this HttpRequestMessage requestMessage, string token)
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static async Task VerifySuccessAsync(this HttpResponseMessage responseMessage)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                return;
            }

            var errorMessage = await responseMessage.Content.ReadAsStringAsync();
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(errorMessage);
                case HttpStatusCode.Conflict:
                    throw new ConflictException(errorMessage);
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException(errorMessage);
                default:
                    throw new BadRequestException(errorMessage);
            }
        }

        public static async Task<T> ReadAsAsync<T>(this HttpResponseMessage responseMessage)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();

            #pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<T>(content);
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
