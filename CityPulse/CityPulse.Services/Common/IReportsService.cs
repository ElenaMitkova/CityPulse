using CityPulse.Services.Models;

namespace CityPulse.Services.Common
{
    public interface IReportsService
    {
        Task<List<ReportModel>> GetAllReports();
        Task<ReportModel> GetReportById(int reportId);
        Task<List<ReportModel>> GetReportsByUser(string user);
        Task CreateReport(ReportModel model, string userId);
        Task UpdateReport(ReportModel model);
        Task DeleteReport(ReportModel model);
    }
}
