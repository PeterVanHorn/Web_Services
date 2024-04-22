using System.ComponentModel.DataAnnotations;

namespace VanHorn_WebServices_Final.Models
{
    public class Day
    {
        [Key]
        public int DId { get; set; }
        public string DayName { get; set; }
        public DateOnly DateOnly { get; set; }
        public virtual List<Timeslot> Timeslots { get; set; }
        public Month Month { get; set; }
        public int? MonthId { get; set; }
    }
}
