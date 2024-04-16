using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgileWorksiTest.Models;
using AgileWorksiTest.Service;
using System.Globalization;

namespace AgileWorksiTest.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    [BindProperty]
    public List<Request>? RequestList { get; set; }
    [BindProperty]
    public string BaseUrl { get; set; } = "http://localhost:5091/api/request/";
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        var list = await RequestService.GetAllRequests(BaseUrl);
        var orderedList = list.OrderBy(x => x.TimeLeft).ToList();
        if (list != null)
        {
            RequestList = orderedList;
        }
        
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var baseUrl = $"http://localhost:5091/api/request/{id}";
        var request = await RequestService.GetRequest(baseUrl);
        request.Status = true;
        var newRequest = await RequestService.PutRequest(baseUrl, request);
        return RedirectToPage("Index");
    }
}
