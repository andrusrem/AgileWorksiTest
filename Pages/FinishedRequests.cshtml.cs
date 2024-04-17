using AgileWorksiTest.Service;
using AgileWorksiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgileWorksiTest.Pages
{
    public class FinishedRequestsModel : PageModel
    {
        private readonly IRequestService _requestService;
        [BindProperty]
        public List<Request>? FinishedRequestList { get; set; }
        [BindProperty]
        public string BaseUrl { get; set; } = "http://localhost:5091/api/request/finished";
        public FinishedRequestsModel(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task OnGet()
        {
            var list = await _requestService.GetAllFinishedRequests(BaseUrl);
            if (list != null)
            {
                FinishedRequestList = list;
            }
        }
    }
}
