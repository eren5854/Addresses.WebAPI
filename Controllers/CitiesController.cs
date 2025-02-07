using Addresses.WebAPI.Abstractions;
using Addresses.WebAPI.DTOs.CityDto;
using Addresses.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Addresses.WebAPI.Controllers;

public sealed class CitiesController(
    ICityService cityService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IEnumerable<CreateCityDto> request, CancellationToken cancellationToken)
    {
        var response = await cityService.Create(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await cityService.GetAll(cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCityDto request, CancellationToken cancellationToken)
    {
        var response = await cityService.Update(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var response = await cityService.Delete(id, cancellationToken);
        return Ok(response);
    }
}
