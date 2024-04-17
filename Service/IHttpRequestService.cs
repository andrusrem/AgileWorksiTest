namespace AgileWorksiTest.Service
{
    public interface IHttpRequestService
    {
        Task<T> SendRequest<T>(string url, HttpMethod method, object data = null);
    }
}
