//Peter Van Horn
//Web Services Final
//05/03/2024
//Credential model
using System.ComponentModel.DataAnnotations;

namespace VanHorn_WebServices_Final.Models
{
    public class Credential
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
