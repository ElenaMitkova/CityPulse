using CityPulse.Models;
using CityPulse.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Services.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ReportStatus Status { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        public District? District { get; set; }
    }
}
