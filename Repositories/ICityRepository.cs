using Addresses.WebAPI.DTOs.CityDto;
using Addresses.WebAPI.Models;

namespace Addresses.WebAPI.Repositories;

public interface ICityRepository
{
    public Task<string> Create(IEnumerable<City> cities, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllCityDto>> GetAll(CancellationToken cancellationToken);
    public Task<City> GetById(string id, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllCityDto>> GetAllByCountryCode(string countryCode, CancellationToken cancellationToken);
    public Task<string> Update(City city, CancellationToken cancellationToken);
    public Task<string> Delete(string id, CancellationToken cancellationToken);
}
