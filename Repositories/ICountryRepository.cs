using Addresses.WebAPI.DTOs.CountryDto;
using Addresses.WebAPI.Models;

namespace Addresses.WebAPI.Repositories;

public interface ICountryRepository
{
    public Task<string> Create(IEnumerable<Country> countries, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllCountryDto>> GetAll(CancellationToken cancellationToken);
    public Task<Country> GetById(string id, CancellationToken cancellationToken);
    public Task<string> Update(Country country, CancellationToken cancellationToken);
    public Task<string> Delete(string id, CancellationToken cancellationToken);
}
