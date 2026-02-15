using CityPulse.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CityPulse.Common.EntityValidations.Report;

namespace CityPulse.ViewModels
{
    public class ReportViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ReportTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

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
