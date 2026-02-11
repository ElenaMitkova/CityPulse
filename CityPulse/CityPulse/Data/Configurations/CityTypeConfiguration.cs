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
                Name = "Sofia"
            },
            new City
            {
                Name = "Plovdiv"
            },
            new City
            {
                Name = "Varna"
            },
            new City
            {
                Name = "Blagoevgrad"
            },
            new City
            {
                Name = "Burgas"
            },
            new City
            {
                Name = "Vidin"
            },
            new City
            {
                Name = "Pleven"
            },
            new City
            {
                Name = "Ruse"
            }
        };
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(Cities);
        }
    }
}
