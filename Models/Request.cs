using Azure.Core;
using System.Globalization;

namespace AgileWorksiTest.Models
{
    public class Request
    {
        public int Id { get; set;}
        public string Description { get; set; }
        public DateTime WhenMade { get; set; } = DateTime.Now;
        public DateTime WhenFinish { get; set; }
        public TimeSpan TimeLeft { get{
                if (Status == false)
                {
                    var dif = WhenFinish - DateTime.Now;
                    return dif;
                }
                else {
                    var dif = WhenFinish - WhenMade;
                    return dif;
                }
           
            } }
        public string Deadline
        {
            get
            {
                var dif = TimeLeft;
                string formatted = string.Format(
                                           CultureInfo.CurrentCulture,
                                           "{0} days, {1} hours, {2} minutes, {3} seconds",
                                           dif.Days,
                                           dif.Hours,
                                           dif.Minutes,
                                           dif.Seconds);
                return formatted;
            }
        }
        //public User Customer { get; set; }
        public bool Status { get; set; } = false;
    }
}