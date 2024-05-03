//Peter Van Horn
//Web Services Final
//05/03/2024
//Day model

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
