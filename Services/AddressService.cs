using Addresses.WebAPI.DTOs.CityDto;
using Addresses.WebAPI.DTOs.CountryDto;
using Addresses.WebAPI.DTOs.TownDto;
using Addresses.WebAPI.Repositories;

namespace Addresses.WebAPI.Services;

public sealed class AddressService(
    ICountryRepository countryRepository,
    ICityRepository cityRepository,
    ITownRepository townRepository) : IAddressService
{
    public async Task<IEnumerable<GetAllCityDto>> City(string countryCode, CancellationToken cancellationToken)
    {
        return await cityRepository.GetAllByCountryCode(countryCode, cancellationToken);
    }

    public async Task<IEnumerable<GetAllCountryDto>> Country(CancellationToken cancellationToken)
    {
        return await countryRepository.GetAll(cancellationToken);
    }

    public async Task<IEnumerable<GetAllTownDto>> Town(string cityCode, CancellationToken cancellationToken)
    {
        return await townRepository.GetAllByCityCode(cityCode, cancellationToken);
    }
}
