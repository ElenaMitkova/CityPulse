using CityPulse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityPulse.Data.Configurations
{
    public class DistrictTypeConfiguration : IEntityTypeConfiguration<District>
    {
        private readonly List<District> Districts = new List<District>()
        {
            new District
            {
                Id = 1,
                Name = "Lozenets",
                CityId = 1
            },
            new District
            {
                Id = 2,
                Name = "Mladost", 
                CityId = 1 
            },
            new District 
            {
                Id = 3,
                Name = "Lyulin",
                CityId = 1 
            },
            new District 
            {
                Id = 4,
                Name = "Studentski Grad", 
                CityId = 1 
            },
            new District 
            { 
                Id = 5,
                Name = "Triaditsa", 
                CityId = 1 
            },
            new District
            { 
                Id = 6,
                Name = "Tsentralen",
                CityId = 2 
            },
            new District 
            { 
                Id = 7,
                Name = "Trakia", 
                CityId = 2 
            },
            new District 
            {
                Id = 8,
                Name = "Severen", 
                CityId = 2 
            },
            new District 
            {
                Id = 9,
                Name = "Primorski",
                CityId = 3 
            },
            new District 
            {
                Id = 10,
                Name = "Odessos", 
                CityId = 3 
            },
            new District 
            {
                Id = 11,
                Name = "Asparuhovo", 
                CityId = 3 
            },
            new District
            {
                Id = 12,
                Name = "Elenovo",
                CityId = 4
            },
            new District 
            {
                Id = 13,
                Name = "Strumsko",
                CityId = 4 
            },
            new District 
            {
                Id = 14,
                Name = "Lazur", 
                CityId = 5 
            },
            new District 
            {
                Id = 15,
                Name = "Meden Rudnik",
                CityId = 5 
            },
            new District 
            {
                Id = 16,
                Name = "Sarafovo",
                CityId = 5 
            },
            new District 
            {
                Id = 17,
                Name = "Kaloian",
                CityId = 6 
            },
            new District 
            {
                Id = 18,
                Name = "Bononia", 
                CityId = 6 
            },
            new District 
            {
                Id = 19,
                Name = "Druzhba", 
                CityId = 7 
            },
            new District 
            {
                Id = 20,
                Name = "Storgozia", 
                CityId = 7 
            },
            new District 
            {
                Id = 21,
                Name = "Vazrazhdane", 
                CityId = 8 
            },
            new District 
            {
                Id = 22,
                Name = "Charodeika",
                CityId = 8 
            }
        };
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasData(Districts);
        }
    }
}
