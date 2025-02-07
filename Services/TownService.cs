using Addresses.WebAPI.DTOs.TownDto;
using Addresses.WebAPI.Models;
using Addresses.WebAPI.Repositories;

namespace Addresses.WebAPI.Services;

public sealed class TownService(
    ITownRepository townRepository) : ITownService
{
    public async Task<string> Create(IEnumerable<CreateTownDto> request, CancellationToken cancellationToken)
    {
        List<Town> towns = new();
        foreach (var town in request)
        {
            towns.Add(new Town
            {
                Name = town.Name,
                Code = town.Code,
                CityCode = town.CityCode
            });
        };
        return await townRepository.Create(towns, cancellationToken);
    }

    public async Task<string> Delete(string id, CancellationToken cancellationToken)
    {
        return await townRepository.Delete(id, cancellationToken);
    }

    public async Task<IEnumerable<GetAllTownDto>> GetAll(CancellationToken cancellationToken)
    {
        return await townRepository.GetAll(cancellationToken);
    }

    public async Task<Town> GetById(string id, CancellationToken cancellationToken)
    {
        return await townRepository.GetById(id, cancellationToken);
    }

    public async Task<string> Update(UpdateTownDto request, CancellationToken cancellationToken)
    {
        Town town = await townRepository.GetById(request.Id, cancellationToken);
        if (town == null)
        {
            return "Town not found";
        }

        town.Name = request.Name;
        town.Code = request.Code;
        town.CityCode = request.CityCode;

        return await townRepository.Update(town, cancellationToken);
    }
}
