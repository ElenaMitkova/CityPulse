using CityPulse.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPulse.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter city name!")]
        [MaxLength(100)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

        public int ReportId { get; set; }

        [Required]
        [ForeignKey(nameof(Report))]
        public Report Report { get; set; } = null!;
    }
}
