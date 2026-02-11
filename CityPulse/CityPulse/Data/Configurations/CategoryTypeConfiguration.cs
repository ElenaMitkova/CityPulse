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
                Name = "Potholes / Road Damage"
            },
            new Category
            {
                Name = "Sidewalks / Pedestrian Zones"
            },
            new Category
            {
                Name = "Street Lighting"
            },
            new Category
            {
                Name = "Park Furniture"
            },
            new Category
            {
                Name = "Playgrounds / Sports Facilities"
            },
            new Category
            {
                Name = "Other"
            }
        };

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(Categories);
        }
    }
}
