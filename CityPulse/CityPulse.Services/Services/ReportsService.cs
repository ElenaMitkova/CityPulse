using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Models.Enums;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Services.Services
{
    public class ReportsService(ApplicationDbContext context) : IReportsService
    {
        public async Task CreateReport(ReportModel model, string userId)
        {
            Report report = new Report
            {
                Title = model.Title,
                Description = model.Description,
                CreatedAt = DateTime.Now,
                UserId = userId,
                Status = ReportStatus.Pending,
                CategoryId = model.CategoryId,
                DistrictId = model.DistrictId
            };
            await context.Reports.AddAsync(report);
            await context.SaveChangesAsync();
        }

        public async Task DeleteReport(ReportModel model)
        {
            Report report = context.Reports.Single(x => x.Id == model.Id);
            context.Reports.Remove(report);
            await context.SaveChangesAsync();
        }

        public async Task<ReportServiceModel> GetAllReports(string? searchTerm = null, int currentPage = 1,
            int reportsPerPage = 6)
        {
            IQueryable<Report> reports = context.Reports.AsNoTracking();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                reports = reports.Where(x => (x.Title.ToLower().Contains(searchTerm) ||
                                                x.Description.ToLower().Contains(searchTerm)));
            }

            int count = await reports.CountAsync();

            List<ReportModel> models = await reports.OrderByDescending(r => r.CreatedAt)
                                        .Skip((currentPage - 1) * reportsPerPage).Take(reportsPerPage)
                                        .Select(r => new ReportModel
                                        {
                                            Id = r.Id,
                                            Title = r.Title,
                                            Description = r.Description,
                                            Status = r.Status,
                                            CategoryId = r.CategoryId,
                                            DistrictId = r.DistrictId,
                                        }).ToListAsync();
            var returnModel = new ReportServiceModel
            {
                TotalReportsCount = count,
                Reports = models
            };
            return returnModel;
        }

        public async Task<ReportModel> GetReportById(int reportId)
        {
            ReportModel reportModel = await context.Reports
                        .Include(x => x.Category)
                        .Include(x => x.District)
                        .Select(x => new ReportModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Description = x.Description,
                            Status = x.Status,
                            UserId = x.UserId,
                            CategoryId = x.CategoryId,
                            CreatedOn = x.CreatedAt,
                            DistrictId = x.DistrictId,
                            District = context.Districts.Include(c => c.City)
                                                        .Where(d => d.Id == x.DistrictId).Single()
                        }).FirstAsync(x => x.Id == reportId);
            return reportModel;
        }

        public async Task<List<ReportModel>> GetReportsByUser(string user)
        {
            IQueryable<ReportModel> reportModels = context.Reports
                        .Include(x => x.Category)
                        .Include(x => x.District)
                        .Where(x => x.UserId == user)
                        .Select(x => new ReportModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Description = x.Description,
                            Status = x.Status,
                            CategoryId = x.CategoryId,
                            DistrictId = x.DistrictId,
                            District = context.Districts.Include(c => c.City)
                                                        .Where(d => d.Id == x.DistrictId).Single()
                        });
            return await reportModels.ToListAsync();
        }

        public async Task UpdateReport(ReportModel model)
        {
            Report report = context.Reports.Single(x => x.Id == model.Id);
            report.Title = model.Title;
            report.Description = report.Description;
            report.Status = model.Status;
            report.DistrictId = model.DistrictId;
            await context.SaveChangesAsync();
        }
    }
}
