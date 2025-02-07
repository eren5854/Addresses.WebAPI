using Addresses.WebAPI.Context;
using Addresses.WebAPI.DTOs.CountryDto;
using Addresses.WebAPI.Models;
using MongoDB.Driver;

namespace Addresses.WebAPI.Repositories;

public sealed class CountryRepository(
    ApplicationDbContext context) : ICountryRepository 
{
    private readonly IMongoCollection<Country> _countries =
       context.Database?.GetCollection<Country>("Countries")
       ?? throw new ArgumentNullException(nameof(context.Database), "Database connection is not initalized");

    public async Task<string> Create(IEnumerable<Country> countries, CancellationToken cancellationToken)
    {
        await _countries.InsertManyAsync(countries, cancellationToken: cancellationToken);
        return "Countries created successfully";
    }

    public async Task<string> Delete(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Country>.Filter.Eq(x => x.Id, id);
        if (filter is null)
        {
            return "Country not found";
        }

        await _countries.DeleteOneAsync(filter, cancellationToken);
        return "Country deleted successfully";
    }

    public async Task<IEnumerable<GetAllCountryDto>> GetAll(CancellationToken cancellationToken)
    {
        var countries = await _countries.Find(FilterDefinition<Country>.Empty).ToListAsync(cancellationToken);
        return countries.Select(s => new GetAllCountryDto(
            s.Name!,
            s.Code!
            )).ToList();
    }

    public async Task<Country> GetById(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Country>.Filter.Eq(x => x.Id, id);
        return await _countries.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    //public async Task<Country> GetByCode(string code, CancellationToken cancellationToken)
    //{
    //    var filter = Builders<Country>.Filter.Eq(x => x.Code, code);
    //    var country = await _countries.Find(filter).FirstOrDefaultAsync(cancellationToken);
    //    return new Country(
    //        country.Name!,
    //        country.Code!
    //        );
    //}

    public async Task<string> Update(Country country, CancellationToken cancellationToken)
    {
        var filter = Builders<Country>.Filter.Eq(x => x.Id, country.Id);
        if (filter is null)
        {
            return "Country not found";
        }

        var result = await _countries.ReplaceOneAsync(filter, country);
        return "Country updated successfully";
    }
}
