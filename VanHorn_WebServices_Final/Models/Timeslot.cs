namespace VanHorn_WebServices_Final.Models
{
    public class Timeslot
    {
        public int TimeslotId { get; set; }
        public Day Day { get; set; }
        public int? DayId { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public int? ServiceProviderId { get; set; }
    }
}
