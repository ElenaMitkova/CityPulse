using CityPulse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityPulse.Data.Configurations
{
    public class CityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        private readonly List<City> Cities = new List<City>
        {
            new City
            {
                Id = 1,
                Name = "Sofia"
            },
            new City
            {
                Id = 2,
                Name = "Plovdiv"
            },
            new City
            {
                Id = 3,
                Name = "Varna"
            },
            new City
            {
                Id = 4,
                Name = "Blagoevgrad"
            },
            new City
            {
                Id = 5,
                Name = "Burgas"
            },
            new City
            {
                Id = 6,
                Name = "Vidin"
            },
            new City
            {
                Id = 7,
                Name = "Pleven"
            },
            new City
            {
                Id = 8,
                Name = "Ruse"
            }
        };
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(Cities);
        }
    }
}
