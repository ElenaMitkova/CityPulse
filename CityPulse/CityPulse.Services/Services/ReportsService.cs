using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Models.Enums;
using CityPulse.Services.Common;
using CityPulse.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Services.Services
{
    public class ReportsService(ApplicationDbContext context) : IReportsService
    {
        public async Task CreateReport(ReportModel model)
        {
            Report report = new Report
            {
                Title = model.Title,
                Description = model.Description,
                CreatedAt = DateTime.Now,
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

        public async Task<List<ReportModel>> GetAllReports()
        {
            IQueryable<ReportModel> reportModels = context.Reports
                        .Include(x => x.Category)
                        .Include(x => x.District)
                            .ThenInclude(x => x.City)
                        .Select(x => new ReportModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Description = x.Description,
                            Status = x.Status,
                            CategoryId = x.CategoryId,
                            DistrictId = x.DistrictId
                        });
            return await reportModels.ToListAsync();
        }

        public async Task UpdateReport(ReportModel model)
        {
            Report report = context.Reports.Single(x => x.Id == model.Id);
            report.Title = model.Title;
            report.Description = report.Description;
            report.Status = report.Status;
        }
    }
}
