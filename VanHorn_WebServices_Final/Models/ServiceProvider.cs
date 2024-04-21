using System.ComponentModel.DataAnnotations;

namespace VanHorn_WebServices_Final.Models
{
    public class ServiceProvider
    {
        [Key]
        public int SPId { get; set; }
        public string BusinessName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public List<Timeslot> Timeslots { get; set; }
    }
}
