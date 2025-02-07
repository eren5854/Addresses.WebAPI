using Addresses.WebAPI.DTOs.CityDto;
using Addresses.WebAPI.DTOs.CountryDto;
using Addresses.WebAPI.DTOs.TownDto;

namespace Addresses.WebAPI.Services;

public interface IAddressService
{
    public Task<IEnumerable<GetAllCountryDto>> Country(CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllCityDto>> City(string countryCode, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllTownDto>> Town(string cityCode, CancellationToken cancellationToken);
}
