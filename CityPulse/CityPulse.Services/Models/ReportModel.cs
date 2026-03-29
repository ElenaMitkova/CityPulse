using CityPulse.Models;
using CityPulse.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityPulse.Services.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ReportStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UserId { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        public District? District { get; set; }
    }
}
