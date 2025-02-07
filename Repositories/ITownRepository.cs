using Addresses.WebAPI.DTOs.TownDto;
using Addresses.WebAPI.Models;

namespace Addresses.WebAPI.Repositories;

public interface ITownRepository
{
    public Task<string> Create(IEnumerable<Town> towns, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllTownDto>> GetAll(CancellationToken cancellationToken);
    public Task<Town> GetById(string id, CancellationToken cancellationToken);
    public Task<IEnumerable<GetAllTownDto>> GetAllByCityCode(string cityCode, CancellationToken cancellationToken);
    public Task<string> Update(Town town, CancellationToken cancellationToken);
    public Task<string> Delete(string id, CancellationToken cancellationToken);
}
