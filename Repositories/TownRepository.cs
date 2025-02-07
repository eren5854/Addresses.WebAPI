using Addresses.WebAPI.Context;
using Addresses.WebAPI.DTOs.TownDto;
using Addresses.WebAPI.Models;
using MongoDB.Driver;

namespace Addresses.WebAPI.Repositories;

public sealed class TownRepository(
    ApplicationDbContext context) : ITownRepository
{
    private readonly IMongoCollection<Town> _town =
     context.Database?.GetCollection<Town>("Towns")
     ?? throw new ArgumentNullException(nameof(context.Database), "Database connection is not initalized");

    public async Task<string> Create(IEnumerable<Town> towns, CancellationToken cancellationToken)
    {
        await _town.InsertManyAsync(towns, cancellationToken: cancellationToken);
        return "Towns created successfully";
    }

    public async Task<string> Delete(string id, CancellationToken cancellationToken)
    {
        var town = Builders<City>.Filter.Eq(x => x.Id, id);
        if (town is null)
        {
            return "Town not found";
        }
        await _town.DeleteOneAsync(x => x.Id == id, cancellationToken);
        return "Town deleted successfully";
    }

    public async Task<IEnumerable<GetAllTownDto>> GetAll(CancellationToken cancellationToken)
    {
        var towns = await _town.Find(FilterDefinition<Town>.Empty).ToListAsync(cancellationToken);
        return towns.Select(s => new GetAllTownDto(
            s.Name!,
            s.Code!
            )).ToList();
    }

    public async Task<IEnumerable<GetAllTownDto>> GetAllByCityCode(string cityCode, CancellationToken cancellationToken)
    {
        var towns = await _town.Find(x => x.CityCode == cityCode).ToListAsync(cancellationToken);
        return towns.Select(s => new GetAllTownDto(
            s.Name!,
            s.Code!
            )).ToList();
    }

    public async Task<Town> GetById(string id, CancellationToken cancellationToken)
    {
        var towns = await _town.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        return towns;
    }

    public async Task<string> Update(Town town, CancellationToken cancellationToken)
    {
        await _town.ReplaceOneAsync(x => x.Id == town.Id, town);
        return "Town updated successfully";
    }
}
