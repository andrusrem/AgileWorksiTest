using AgileWorksiTest.Models;

namespace AgileWorksiTest.Service
{
    public interface IRequestService
    {
        Task<List<Request>?> GetAllRequests(string baseUrl);
        Task<List<Request>?> GetAllFinishedRequests(string baseUrl);
        Task<Request>? GetRequest(string baseUrl);
        Task<Request>? PostRequest(string baseUrl, object body);
        Task<int> GiveId(string baseUrl);
        Task<Request>? PutRequest(string baseUrl, Request request);
        Task<Request> DeleteRequest(string baseUrl);
    }
}
