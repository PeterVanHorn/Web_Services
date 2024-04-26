using System.ComponentModel.DataAnnotations;

namespace VanHorn_WebServices_Final.Models
{
    public class Day
    {
        [Key]
        public string Id { get; set; }
        public virtual List<Timeslot> Timeslots { get; set; }
    }
}
