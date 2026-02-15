using CityPulse.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CityPulse.Common.EntityValidations;
using static CityPulse.Common.EntityValidations.Report;

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

        [Column(TypeName = DateTimeColumnType)]
        public DateTime CreatedAt { get; set; }

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

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;
    }
}
