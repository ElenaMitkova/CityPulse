using CityPulse.Services.Models;

namespace CityPulse.Services.Common
{
    public interface IReportsService
    {
        Task<ReportServiceModel> GetAllReports(string? searchTerm = null, int currentPage = 1,
            int reportsPerPage = 6);
        Task<ReportModel> GetReportById(int reportId);
        Task<List<ReportModel>> GetReportsByUser(string user);
        Task CreateReport(ReportModel model, string userId);
        Task UpdateReport(ReportModel model);
        Task DeleteReport(ReportModel model);
    }
}
