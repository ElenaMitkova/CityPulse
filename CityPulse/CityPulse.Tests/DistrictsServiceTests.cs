using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Services.Models;
using CityPulse.Services.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CityPulse.Tests
{
    public class DistrictsServiceTests
    {
        private DbContextOptions<ApplicationDbContext> Get()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        private async Task SeedDistricts(ApplicationDbContext context)
        {
            var city = new City 
            { 
                Id = 1, 
                Name = "Sofia" 
            };
            context.Cities.Add(city);

            context.Districts.AddRange(new List<District>
            {
                new District 
                { 
                    Id = 1, 
                    Name = "Mladost", 
                    CityId = 1 
                },
                new District 
                { 
                    Id = 2, 
                    Name = "Lulin", 
                    CityId = 1 
                }
            });

            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllDistricts_ShouldReturnAllWithCities()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            await SeedDistricts(context);
            DistrictsService service = new DistrictsService(context);

            List<District> result = await service.GetAllDistricts();

            Assert.Equal(2, result.Count);
            Assert.Equal("Sofia", result.First().City.Name);
        }

        [Fact]
        public async Task GetAllDistrictsByGroup_ShouldGroupCorrectly()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            await SeedDistricts(context);
            DistrictsService service = new DistrictsService(context);

            List<GroupedDistricts> result = await service.GetAllDistrictsByGroup();

            Assert.Single(result);
            Assert.Equal("Sofia", result.First().City);
            Assert.Equal(2, result.First().Districts.Count());
        }

        [Fact]
        public async Task GetAllDistrictsByCity_ShouldFilterByCityId()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            await SeedDistricts(context);

            context.Cities.Add(new City 
            { 
                Id = 2, 
                Name = "Plovdiv" 
            });
            context.Districts.Add(new District 
            { 
                Id = 3, 
                Name = "Trakia", 
                CityId = 2 
            });
            await context.SaveChangesAsync();

            DistrictsService service = new DistrictsService(context);

            List<District> result = await service.GetAllDistrictsByCity(1);

            Assert.Equal(2, result.Count);
            Assert.All(result, d => Assert.Equal(1, d.CityId));
        }

        [Fact]
        public async Task CreateDistrict_ShouldAssignCorrectCityId()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            DistrictsService service = new DistrictsService(context);
            District newDistrict = new District 
            { 
                Name = "Vitosha" 
            };

            await service.CreateDistrict(newDistrict, 5); 

            District? saved = await context.Districts.FirstOrDefaultAsync(d => d.Name == "Vitosha");
            Assert.NotNull(saved);
            Assert.Equal(5, saved.CityId);
        }

        [Fact]
        public async Task DeleteDistrict_ShouldRemoveFromDb()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            await SeedDistricts(context);
            DistrictsService service = new DistrictsService(context);

            await service.DeleteDistrict(1);

            District? district = await context.Districts.FindAsync(1);
            Assert.Null(district);
            Assert.Equal(1, await context.Districts.CountAsync());
        }

        [Fact]
        public async Task DeleteDistrict_ShouldThrowException_IfNotFound()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            DistrictsService service = new DistrictsService(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.DeleteDistrict(999));
        }
    }
}
