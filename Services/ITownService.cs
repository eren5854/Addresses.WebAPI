using Addresses.WebAPI.DTOs.TownDto;
using Addresses.WebAPI.Models;

namespace Addresses.WebAPI.Services;

public interface ITownService
{
    public Task<string> Create(IEnumerable<CreateTownDto> request, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllTownDto>> GetAll(CancellationToken cancellationToken);
    public Task<Town> GetById(string id, CancellationToken cancellationToken);
    public Task<string> Update(UpdateTownDto request, CancellationToken cancellationToken);
    public Task<string> Delete(string id, CancellationToken cancellationToken);
}
