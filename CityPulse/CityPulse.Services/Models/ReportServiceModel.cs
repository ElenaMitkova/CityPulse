namespace CityPulse.Services.Models
{
    public class ReportServiceModel
    {
        public int TotalReportsCount { get; set; }
        public IEnumerable<ReportModel> Reports { get; set; } = new List<ReportModel>();
    }
}