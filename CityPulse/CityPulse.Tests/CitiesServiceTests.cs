using CityPulse.Data;
using CityPulse.Models;
using CityPulse.Services.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CityPulse.Tests
{
    public class CitiesServiceTests
    {
        private DbContextOptions<ApplicationDbContext> Get()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetAllCities_ShouldReturnEmptyList_WhenNoCitiesExist()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            CitiesService service = new CitiesService(context);

            List<City> result = await service.GetAllCities();

            Assert.Empty(result);
        }

        [Fact]
        public async Task CreateCity_ShouldSuccessfullyAddCityToDatabase()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            CitiesService service = new CitiesService(context);
            City newCity = new City
            { 
                Name = "Varna" 
            };

            await service.CreateCity(newCity);

            City? cityInDb = await context.Cities.FirstOrDefaultAsync(c => c.Name == "Varna");
            Assert.NotNull(cityInDb);
            Assert.Equal("Varna", cityInDb.Name);
        }

        [Fact]
        public async Task GetCityById_ShouldReturnCorrectCity()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            City city = new City { Id = 5, Name = "Burgas" };
            context.Cities.Add(city);
            await context.SaveChangesAsync();

            CitiesService service = new CitiesService(context);

            City result = await service.GetCityById(5);

            Assert.NotNull(result);
            Assert.Equal("Burgas", result.Name);
        }

        [Fact]
        public async Task GetCityById_ShouldThrowException_WhenIdDoesNotExist()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            CitiesService service = new CitiesService(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetCityById(999));
        }

        [Fact]
        public async Task DeleteCity_ShouldRemoveCityFromDatabase()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            City city = new City
            { 
                Id = 1, 
                Name = "Ruse" 
            };
            context.Cities.Add(city);
            await context.SaveChangesAsync();

            CitiesService service = new CitiesService(context);

            await service.DeleteCity(1);

            var deletedCity = await context.Cities.FindAsync(1);
            Assert.Null(deletedCity);
            Assert.Equal(0, await context.Cities.CountAsync());
        }

        [Fact]
        public async Task DeleteCity_ShouldThrowException_WhenDeletingNonExistentCity()
        {
            DbContextOptions<ApplicationDbContext> options = Get();
            ApplicationDbContext context = new ApplicationDbContext(options);
            CitiesService service = new CitiesService(context);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.DeleteCity(888));
        }
    }
}
