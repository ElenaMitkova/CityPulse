using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CityPulse.Common.EntityValidations;

namespace CityPulse.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Author))]
        public int? AuthorId { get; set; }

        public User Author { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [Required]
        [Column(DateTimeColumnType)]
        public DateTime PublishedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Report))]
        public int ReportId { get; set; }

        public Report Report { get; set; } = null!;
    }
}
