using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Services.Models;
using CityPulse.Services.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CityPulse.Tests
{
    public class ReportsServiceTests
    {
        private DbContextOptions<ApplicationDbContext> Get()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        }

        [Fact]
        public async Task CreateReport_ShouldSaveReportToDatabase()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            ReportsService service = new ReportsService(context);

            ReportModel model = new ReportModel
            {
                Title = "Test Title",
                Description = "Test Description",
                CategoryId = 1,
                DistrictId = 1
            };
            string userId = "user-123";

            await service.CreateReport(model, userId);

            Report? report = await context.Reports.FirstOrDefaultAsync();
            Assert.NotNull(report);
            Assert.Equal("Test Title", report.Title);
            Assert.Equal(userId, report.UserId);
        }

        [Fact]
        public async Task GetAllReports_ShouldFilterBySearchTerm()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);

            context.Reports.AddRange(new List<Report>
            {
                new Report
                { 
                    Title = "Broken Bench", 
                    Description = "In the park", 
                    CreatedAt = DateTime.Now,
                    UserId = "testUser1" 
                },
                new Report 
                { 
                    Title = "Street Light", 
                    Description = "Dark alley", 
                    CreatedAt = DateTime.Now,
                    UserId = "testUser2"
                }
            });
            await context.SaveChangesAsync();

            ReportsService service = new ReportsService(context);

            ReportServiceModel result = await service.GetAllReports(searchTerm: "Bench");

            Assert.Single(result.Reports);
            Assert.Equal("Broken Bench", result.Reports.First().Title);
        }

        [Fact]
        public async Task UpdateReport_ShouldThrowException_WhenReportNotFound()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            ReportsService service = new ReportsService(context);
            ReportModel model = new ReportModel 
            { 
                Id = 999 
            };

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await service.UpdateReport(model));
        }

        [Fact]
        public async Task GetAllReports_ShouldReturnCorrectPage_WhenPaginationIsApplied()
        {
            var options = Get();
            using var context = new ApplicationDbContext(options);
            var service = new ReportsService(context);

            for (int i = 1; i <= 5; i++)
            {
                context.Reports.Add(new Report { Id = i, Title = $"Report {i}", Description = "Desc", CreatedAt = DateTime.Now, UserId = "1" });
            }
            await context.SaveChangesAsync();

            var result = await service.GetAllReports(currentPage: 2, reportsPerPage: 2);

            Assert.Equal(2, result.Reports.Count());
            Assert.Equal(5, result.TotalReportsCount);
        }

        [Fact]
        public async Task GetAllReports_ShouldFilterByDescription_IgnoringCase()
        {
            var options = Get();
            using var context = new ApplicationDbContext(options);
            context.Reports.Add(new Report { Title = "Title", Description = "CRITICAL ERROR", CreatedAt = DateTime.Now, UserId = "1" });
            await context.SaveChangesAsync();
            var service = new ReportsService(context);

            var result = await service.GetAllReports(searchTerm: "critical");

            Assert.Single(result.Reports);
            Assert.Contains("CRITICAL ERROR", result.Reports.First().Description);
        }

        [Fact]
        public async Task DeleteReport_ShouldSuccessfullyRemoveReport()
        {
            var options = Get();
            using var context = new ApplicationDbContext(options);
            var report = new Report { Id = 10, Title = "To be deleted", Description = "Desc", UserId = "1" };
            context.Reports.Add(report);
            await context.SaveChangesAsync();

            var service = new ReportsService(context);
            var model = new ReportModel { Id = 10 };

            await service.DeleteReport(model);

            var deletedReport = await context.Reports.FindAsync(10);
            Assert.Null(deletedReport);
        }
    }
}
