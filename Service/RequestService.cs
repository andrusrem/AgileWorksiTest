using AgileWorksiTest.Models;

namespace AgileWorksiTest.Service
{
    public class RequestService
    {
        public static async Task<List<Request>?> GetAllRequests(string baseUrl)
        {
            Console.WriteLine("GetAllRequests");
            var requests = await HttpRequestService.SendRequest<List<Request>?>(baseUrl, HttpMethod.Get, null);
            Console.WriteLine(requests);
            return requests;
        }
        public static async Task<Request>? PostRequest(string baseUrl, object body)
        {
            Console.WriteLine("GetAllRequests");
            var request = await HttpRequestService.SendRequest<Request>(baseUrl, HttpMethod.Post, body);
            Console.WriteLine(request);
            return request;
        }

        public static async Task<int> GiveId(string baseUrl)
        {
            var requests = await HttpRequestService.SendRequest<List<Request>?>(baseUrl, HttpMethod.Get, null);
            var nextId = requests.Count;
            return nextId;
        }
    }
}
