using System.ComponentModel.DataAnnotations;
using static CityPulse.Common.EntityValidations.Category;
using static CityPulse.Common.EntityValidations.ValidationMessages;

namespace CityPulse.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = CategoryErrorMessage)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Report> Reports { get; set; } = new HashSet<Report>();
    }
}
