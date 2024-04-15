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
    [BindProperty]
    public string Desc { get; set; }
    [BindProperty]
    public DateTime WhenFin { get; set; }
    [BindProperty]
    public List<Request> RequestList { get; set; }
    [BindProperty]
    public string BaseUrl { get; set; } = "http://localhost:5091/api/request/";
    public RequestCreateModel()
    {
        
    }

    public async Task OnGet()
    {
        var list = await RequestService.GetAllRequests(BaseUrl);
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
            int nextId = await RequestService.GiveId(BaseUrl);
            id = nextId;
        }
        TimeSpan dif = WhenFin - DateTime.Now;
        double hours = dif.TotalHours;
        var newRequest = await RequestService.PostRequest(BaseUrl, new { Id = id,Description = Desc, WhenFinish = WhenFin, TimeLeft = hours});

        return RedirectToPage("Index");

    }
}

