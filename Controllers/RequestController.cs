using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgileWorksiTest.Models;

namespace AgileWorksiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        public static List<Request> ActiveRequests = new List<Request>();
        public static List<Request> FinishedRequests = new List<Request>();

        [HttpGet]
        public IActionResult Get()
        {  
            return Ok(ActiveRequests);
        }
        [HttpGet("finished")]
        public IActionResult GetFinished()
        {
            return Ok(FinishedRequests);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var request = ActiveRequests.Where(u => u.Id == id).FirstOrDefault();
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Request request)
        {
            if (id != request.Id) 
            {
                return BadRequest();
            }
            var savedRequest = ActiveRequests.Where(u => u.Id == id).FirstOrDefault();
            try
            {
                savedRequest.Status = request.Status;
                
            }
            catch (Exception ex) 
            { 
                if (savedRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult Post(Request request)
        {
            ActiveRequests.Add(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var request = ActiveRequests.Where(u => u.Id == id).FirstOrDefault();
            if (request == null)
            {
                return NotFound();
            }
            request.WhenMade = DateTime.Now;
            FinishedRequests.Add(request);
            ActiveRequests.Remove(request);
            return NoContent();
        }

    }
}
