using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VanHorn_WebServices_Final.Models
{
    public class Customer
    {
        [Key]
        public int CId { get; set; }
        public Credential Credential { get; set; }
        [ForeignKey("Credential")]
        public int? CredentialId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Timeslot> Timeslots { get; set; }
    }
}
