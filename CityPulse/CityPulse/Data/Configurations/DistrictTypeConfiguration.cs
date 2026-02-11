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
                Name = "Lozenets",
                CityId = 1
            },
            new District
            { 
                Name = "Mladost", 
                CityId = 1 
            },
            new District 
            { 
                Name = "Lyulin",
                CityId = 1 
            },
            new District 
            { 
                Name = "Studentski Grad", 
                CityId = 1 
            },
            new District 
            { 
                Name = "Triaditsa", 
                CityId = 1 
            },
            new District
            { 
                Name = "Tsentralen",
                CityId = 2 
            },
            new District 
            { 
                Name = "Trakia", 
                CityId = 2 
            },
            new District 
            { 
                Name = "Severen", 
                CityId = 2 
            },
            new District 
            { 
                Name = "Primorski",
                CityId = 3 
            },
            new District 
            { 
                Name = "Odessos", 
                CityId = 3 
            },
            new District 
            { 
                Name = "Asparuhovo", 
                CityId = 3 
            },
            new District
            {
                Name = "Elenovo",
                CityId = 4
            },
            new District 
            { 
                Name = "Strumsko",
                CityId = 4 
            },
            new District 
            { 
                Name = "Lazur", 
                CityId = 5 
            },
            new District 
            { 
                Name = "Meden Rudnik",
                CityId = 5 
            },
            new District 
            { 
                Name = "Sarafovo",
                CityId = 5 
            },
            new District 
            { 
                Name = "Kaloian",
                CityId = 6 
            },
            new District 
            { 
                Name = "Bononia", 
                CityId = 6 
            },
            new District 
            {
                Name = "Druzhba", 
                CityId = 7 
            },
            new District 
            { 
                Name = "Storgozia", 
                CityId = 7 
            },
            new District 
            { 
                Name = "Vazrazhdane", 
                CityId = 8 
            },
            new District 
            { 
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
