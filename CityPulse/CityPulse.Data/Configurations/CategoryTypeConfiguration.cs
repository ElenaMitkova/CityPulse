using CityPulse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityPulse.Data.Configurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Potholes / Road Damage"
            },
            new Category
            {
                Id = 2,
                Name = "Sidewalks / Pedestrian Zones"
            },
            new Category
            {
                Id = 3,
                Name = "Street Lighting"
            },
            new Category
            {
                Id = 4,
                Name = "Park Furniture"
            },
            new Category
            {
                Id = 5,
                Name = "Playgrounds / Sports Facilities"
            },
            new Category
            {
                Id = 6,
                Name = "Other"
            }
        };

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(Categories);
        }
    }
}
