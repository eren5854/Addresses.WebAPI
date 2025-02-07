using Addresses.WebAPI.Abstractions;
using Addresses.WebAPI.DTOs.TownDto;
using Addresses.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Addresses.WebAPI.Controllers;

public sealed class TownsController(
    ITownService townService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IEnumerable<CreateTownDto> request, CancellationToken cancellationToken)
    {
        return Ok(await townService.Create(request, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await townService.GetAll(cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        return Ok(await townService.GetById(id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateTownDto request, CancellationToken cancellationToken)
    {
        return Ok(await townService.Update(request, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        return Ok(await townService.Delete(id, cancellationToken));
    }
}
