using Addresses.WebAPI.DTOs.CountryDto;
using Addresses.WebAPI.Models;
using Addresses.WebAPI.Repositories;

namespace Addresses.WebAPI.Services;

public sealed class CountryService(
    ICountryRepository countryRepository) : ICountryService
{
    public async Task<string> Create(IEnumerable<CreateCountryDto> request, CancellationToken cancellationToken)
    {
        List<Country> countries = new();

        foreach (var item in request)
        {
            countries.Add(new Country
            {
                Name = item.Name,
                Code = item.Code
            });
        }

        return await countryRepository.Create(countries, cancellationToken);
    }

    public async Task<string> Delete(string id, CancellationToken cancellationToken)
    {
        return await countryRepository.Delete(id, cancellationToken);
    }

    public async Task<IEnumerable<GetAllCountryDto>> GetAll(CancellationToken cancellationToken)
    {
        return await countryRepository.GetAll(cancellationToken);
    }

    public async Task<string> Update(UpdateCountryDto request, CancellationToken cancellationToken)
    {
        Country country = await countryRepository.GetById(request.Id, cancellationToken);
        if (country is null)
        {
            return "Country not found";
        }

        country.Name = request.Name;
        country.Code = request.Code;

        return await countryRepository.Update(country, cancellationToken);
    }
}
