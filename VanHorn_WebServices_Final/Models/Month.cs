using System.ComponentModel.DataAnnotations;

namespace VanHorn_WebServices_Final.Models
{
    public class Month
    {
        [Key]
        public int MId { get; set; }
        public string MonthName { get; set; }
        public List<Day> Days { get; set; }
    }
}
