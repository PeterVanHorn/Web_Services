namespace VanHorn_WebServices_Final.Models
{
    public class Month
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public List<Day> Days { get; set; }
    }
}
