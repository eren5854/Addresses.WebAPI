using Addresses.WebAPI.Context;
using Addresses.WebAPI.DTOs.CityDto;
using Addresses.WebAPI.DTOs.CountryDto;
using Addresses.WebAPI.Models;
using MongoDB.Driver;

namespace Addresses.WebAPI.Repositories;

public sealed class CityRepository(
    ApplicationDbContext context) : ICityRepository
{
    private readonly IMongoCollection<City> _cities =
      context.Database?.GetCollection<City>("Cities")
      ?? throw new ArgumentNullException(nameof(context.Database), "Database connection is not initalized");

    public async Task<string> Create(IEnumerable<City> cities, CancellationToken cancellationToken)
    {
        await _cities.InsertManyAsync(cities, cancellationToken: cancellationToken);
        return "Cities created successfully";
    }

    public async Task<string> Delete(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<City>.Filter.Eq(x => x.Id, id);
        if (filter is null)
        {
            return "City not found";
        }

        await _cities.DeleteOneAsync(filter, cancellationToken);
        return "City deleted successfully";
    }

    public async Task<IEnumerable<GetAllCityDto>> GetAll(CancellationToken cancellationToken)
    {
        var cities = await _cities.Find(FilterDefinition<City>.Empty).ToListAsync(cancellationToken);
        return cities.Select(s => new GetAllCityDto(
            s.Name!,
            s.Code!
            )).ToList();
    }

    public async Task<IEnumerable<GetAllCityDto>> GetAllByCountryCode(string countryCode, CancellationToken cancellationToken)
    {
        var cities = await _cities.Find(x => x.CountryCode == countryCode).ToListAsync(cancellationToken);
        return cities.Select(s => new GetAllCityDto(
            s.Name!,
            s.Code!
            )).ToList();
    }

    public async Task<City> GetById(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<City>.Filter.Eq(x => x.Id, id);
        return await _cities.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<string> Update(City city, CancellationToken cancellationToken)
    {
        var filter = Builders<City>.Filter.Eq(x => x.Id, city.Id);
        if (filter is null)
        {
            return "City not found";
        }

        var result = await _cities.ReplaceOneAsync(filter, city);
        return "City updated successfully";
    }
}
