using Addresses.WebAPI.DTOs.CityDto;
using Addresses.WebAPI.Models;
using Addresses.WebAPI.Repositories;

namespace Addresses.WebAPI.Services;

public sealed class CityService(
    ICityRepository cityRepository) : ICityService
{
    public async Task<string> Create(IEnumerable<CreateCityDto> request, CancellationToken cancellationToken)
    {
        List<City> cities = new();

        foreach (var item in request)
        {
            cities.Add(new City
            {
                Name = item.Name,
                Code = item.Code,
                CountryCode = item.CountryCode
            });
        }

        return await cityRepository.Create(cities, cancellationToken);
    }

    public async Task<string> Delete(string id, CancellationToken cancellationToken)
    {
        return await cityRepository.Delete(id, cancellationToken);
    }

    public async Task<IEnumerable<GetAllCityDto>> GetAll(CancellationToken cancellationToken)
    {
        return await cityRepository.GetAll(cancellationToken);
    }

    public Task<City> GetById(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Update(UpdateCityDto request, CancellationToken cancellationToken)
    {
        City city = await cityRepository.GetById(request.Id, cancellationToken);
        if (city is null)
        {
            return "City not found";
        }

        city.Name = request.Name;
        city.Code = request.Code;
        city.CountryCode = request.CountryCode;

        return await cityRepository.Update(city, cancellationToken);
    }
}
