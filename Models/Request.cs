namespace AgileWorksiTest.Models
{
    public class Request
    {
        public string Id { get; set;}
        public string Description { get; set; }
        public DateTime WhenMade { get; set; } = DateTime.Now;
        public DateTime WhenFinish { get; set; }
        public User Customer { get; set; }
        public bool Status { get; set; }
    }
}