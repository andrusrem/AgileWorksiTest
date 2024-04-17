using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgileWorksiTest.Models;
using AgileWorksiTest.Service;

namespace AgileWorksiTest.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class RequestCreateModel : PageModel
{
    private readonly IRequestService _requestService;
    [BindProperty]
    public string Desc { get; set; }
    [BindProperty]
    public DateTime WhenFin { get; set; }
    [BindProperty]
    public List<Request> RequestList { get; set; }
    [BindProperty]
    public string BaseUrl { get; set; } = "http://localhost:5091/api/request/";
    public RequestCreateModel(IRequestService requestService)
    {
        _requestService = requestService;
    }

    public async Task OnGet()
    {
        var list = await _requestService.GetAllRequests(BaseUrl);
        if (list != null)
        {
            RequestList = list;
            RequestList.ToList();
        }
    }

    public async Task<IActionResult> OnPost()
    {
        int id = 0;
        if (RequestList != null)
        {
            int nextId = await _requestService.GiveId(BaseUrl);
            id = nextId;
        }

        var newRequest = await _requestService.PostRequest(BaseUrl, new { Id = id,Description = Desc, WhenFinish = WhenFin});
        
        return RedirectToPage("Index");

    }
}

