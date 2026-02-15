using CityPulse.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Services.Common
{
    public interface IReportsService
    {
        Task<List<ReportModel>> GetAllReports();
        Task CreateReport(ReportModel model);
        Task UpdateReport(ReportModel model);
        Task DeleteReport(ReportModel model);
    }
}
