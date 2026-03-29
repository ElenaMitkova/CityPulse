using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityPulse.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter district name!")]
        [MaxLength()]
        public string Name { get; set; } = null!;


        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public City? City { get; set; }
    }
}
