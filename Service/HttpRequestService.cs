using System.Net.Http.Headers;
using System.Text;

namespace AgileWorksiTest.Service
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<T> SendRequest<T>(string url, HttpMethod method, object data = null)
        {

            var request = new HttpRequestMessage(method, url);


            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            if (data != null)
            {
                request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);
            Console.WriteLine(response.ToString());

            Console.WriteLine("SendRequest");

            var responseData = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseData);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseData);



        }
    }
}
