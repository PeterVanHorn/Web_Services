//Peter Van Horn
//Web Services Final
//05/03/2024
//Timeslot model

using System.ComponentModel.DataAnnotations;

namespace VanHorn_WebServices_Final.Models
{
    public class Timeslot
    {
        [Key]
        public int TId { get; set; }
        public Day Day { get; set; }
        public string DayId { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
        public Business ServiceProvider { get; set; }
        public int? ServiceProviderId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsTaken { get; set; }
    }
}
