using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CityPulse.Common.EntityValidations.Report;
using static CityPulse.Common.EntityValidations;
using CityPulse.Models.Enums;
using Newtonsoft.Json;

namespace CityPulse.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ReportTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longtitude { get; set; }

        [Column(TypeName = DateTimeColumnType)]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = DateTimeColumnType)]
        public DateTime ModifiedOn { get; set; }

        [Required]
        public ReportStatus Status { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Required]
        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        public District? District { get; set; }
    }
}
