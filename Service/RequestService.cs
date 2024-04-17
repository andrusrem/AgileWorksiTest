using AgileWorksiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;

namespace AgileWorksiTest.Service
{
    public class RequestService : IRequestService
    {
        private readonly IHttpRequestService _httpRequestService;
        public RequestService(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }
        public async Task<List<Request>?> GetAllRequests(string baseUrl)
        {
            Console.WriteLine("GetAllRequests");
            var requests = await _httpRequestService.SendRequest<List<Request>?>(baseUrl, HttpMethod.Get, null);
            Console.WriteLine(requests);
            return requests;
        }
        public async Task<List<Request>?> GetAllFinishedRequests(string baseUrl)
        {
            Console.WriteLine("GetAllRequests");
            var requests = await _httpRequestService.SendRequest<List<Request>?>(baseUrl, HttpMethod.Get, null);
            Console.WriteLine(requests);
            return requests;
        }
        public async Task<Request>? GetRequest(string baseUrl)
        {
            Console.WriteLine("GetRequest");
            var request = await _httpRequestService.SendRequest<Request>(baseUrl, HttpMethod.Get, null);
            return request;
        }
        public async Task<Request>? PostRequest(string baseUrl, object body)
        {
            Console.WriteLine("PostRequest");
            var request = await _httpRequestService.SendRequest<Request>(baseUrl, HttpMethod.Post, body);
            Console.WriteLine(request);
            return request;
        }

        public async Task<int> GiveId(string baseUrl)
        {
            var requests = await _httpRequestService.SendRequest<List<Request>?>(baseUrl, HttpMethod.Get, null);
            var nextId = requests.Count;
            return nextId;
        }
        public async Task<Request>? PutRequest(string baseUrl, Request request)
        {
            var req = new {Id = request.Id, Description = request.Description, WhenMade = request.WhenMade, WhenFinish = request.WhenFinish, TimeLeft = request.TimeLeft, DeadLine = request.Deadline, Status = request.Status};
            var newRequest = await _httpRequestService.SendRequest<Request>(baseUrl, HttpMethod.Put, req);
            return newRequest;
        }
        public async Task<Request> DeleteRequest(string baseUrl)
        {
            var delete = await _httpRequestService.SendRequest<Request>(baseUrl, HttpMethod.Delete, null);
            return delete;
        }
    }
}
