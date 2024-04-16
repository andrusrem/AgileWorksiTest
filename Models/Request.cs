using Azure.Core;

namespace AgileWorksiTest.Models
{
    public class Request
    {
        public int Id { get; set;}
        public string Description { get; set; }
        public DateTime WhenMade { get; set; } = DateTime.Now;
        public DateTime WhenFinish { get; set; }
        public double TimeLeft { get{
            var dif = WhenFinish - DateTime.Now;
            return dif.TotalHours;
        } }
        //public User Customer { get; set; }
        public bool Status { get; set; } = false;
    }
}