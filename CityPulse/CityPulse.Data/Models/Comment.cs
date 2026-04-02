using CityPulse.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CityPulse.Common.EntityValidations.ValidationMessages;

namespace CityPulse.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = CommentErrorMessage)]
        [MaxLength(100)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Report))]
        public int ReportId { get; set; }
        
        public Report Report { get; set; } = null!;
    }
}
