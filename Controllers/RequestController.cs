using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgileWorksiTest.Models;

namespace AgileWorksiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        public static List<Request> Requests = new List<Request>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Requests);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var request = Requests.Where(u => u.Id == id).FirstOrDefault();
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
            var savedRequest = Requests.Where(u => u.Id == id).FirstOrDefault();
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
            Requests.Add(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var request = Requests.Where(u => u.Id == id).FirstOrDefault();
            if (request == null)
            {
                return NotFound();
            }
            Requests.Remove(request);
            return NoContent();
        }

    }
}
