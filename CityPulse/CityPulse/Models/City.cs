using System.ComponentModel.DataAnnotations;
using static CityPulse.Common.EntityValidations.City;

namespace CityPulse.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<District> Districts { get; set; } = new HashSet<District>();
    }
}
