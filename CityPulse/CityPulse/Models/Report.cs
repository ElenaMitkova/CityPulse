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

        [Column(DateTimeColumnType)]
        public DateTime CreatedAt { get; set; }

        [Column(DateTimeColumnType)]
        public DateTime ModifiedOn { get; set; }

        [Required]
        public ReportStatus Status { get; set; }

        [ForeignKey(nameof(Author))]
        public int? AuthorId { get; set; }

        public User? Author { get; set; }

        [ForeignKey(nameof(Modifier))]
        public int? ModifierId { get; set; }

        public User? Modifier { get; set; }

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
