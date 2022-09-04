using AirlineSendAgent.Dtos;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirlineSendAgent.Client
{
    public class WebhookClient : IWebhookClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WebhookClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendWebhookNotification(FlightDetailChangePayloadDto flightDetailChangePayloadDto)
        {
            var payload = JsonSerializer.Serialize(flightDetailChangePayloadDto);

            var httpClient = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, flightDetailChangePayloadDto.WebhookURI);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(payload);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                using var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
