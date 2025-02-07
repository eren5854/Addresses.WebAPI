using Addresses.WebAPI.DTOs.CountryDto;

namespace Addresses.WebAPI.Services;

public interface ICountryService
{
    public Task<string> Create(IEnumerable<CreateCountryDto> request, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllCountryDto>> GetAll(CancellationToken cancellationToken);
    public Task<string> Update(UpdateCountryDto request, CancellationToken cancellationToken);
    public Task<string> Delete(string id, CancellationToken cancellationToken);

}
