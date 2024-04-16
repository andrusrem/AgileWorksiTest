using AgileWorksiTest.Models;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;

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
        public static async Task<Request>? GetRequest(string baseUrl)
        {
            Console.WriteLine("GetRequest");
            var request = await HttpRequestService.SendRequest<Request>(baseUrl, HttpMethod.Get, null);
            return request;
        }
        public static async Task<Request>? PostRequest(string baseUrl, object body)
        {
            Console.WriteLine("PostRequest");
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
        public static async Task<Request>? PutRequest(string baseUrl, Request request)
        {
            var req = new {Id = request.Id, Description = request.Description, WhenMade = request.WhenMade, WhenFinish = request.WhenFinish, TimeLeft = request.TimeLeft, DeadLine = request.Deadline, Status = request.Status};
            var newRequest = await HttpRequestService.SendRequest<Request>(baseUrl, HttpMethod.Put, req);
            return newRequest;
        }
    }
}
