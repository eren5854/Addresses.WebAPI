using Addresses.WebAPI.Abstractions;
using Addresses.WebAPI.DTOs.CountryDto;
using Addresses.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Addresses.WebAPI.Controllers;

public class CountriesController(
    ICountryService countryService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IEnumerable<CreateCountryDto> request, CancellationToken cancellationToken)
    {
        var response = await countryService.Create(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await countryService.GetAll(cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCountryDto request, CancellationToken cancellationToken)
    {
        var response = await countryService.Update(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await countryService.Delete(id, cancellationToken);
        return Ok(response);
    }
}
