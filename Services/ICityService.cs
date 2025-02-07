using Addresses.WebAPI.DTOs.CityDto;
using Addresses.WebAPI.Models;

namespace Addresses.WebAPI.Services;

public interface ICityService
{
    public Task<string> Create(IEnumerable<CreateCityDto> request, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllCityDto>> GetAll(CancellationToken cancellationToken);
    public Task<City> GetById(string id, CancellationToken cancellationToken);
    public Task<string> Update(UpdateCityDto request, CancellationToken cancellationToken);
    public Task<string> Delete(string id, CancellationToken cancellationToken);
}
