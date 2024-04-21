namespace VanHorn_WebServices_Final.Models
{
    public class Day
    {
        public int DayId { get; set; }
        public string DayName { get; set; }
        public virtual List<Timeslot> Timeslots { get; set; }
        public Month Month { get; set; }
        public int? MonthId { get; set; }
    }
}
