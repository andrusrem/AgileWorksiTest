using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgileWorksiTest.Models;
using AgileWorksiTest.Service;

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
}
