using Addresses.WebAPI.Abstractions;
using Addresses.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Addresses.WebAPI.Controllers;

public sealed class AddressesController(
    IAddressService addressService) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Countries(CancellationToken cancellationToken)
    {
        return Ok(await addressService.Country(cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> Cities(string countryCode, CancellationToken cancellationToken)
    {
        return Ok(await addressService.City(countryCode, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> Towns(string cityCode, CancellationToken cancellationToken)
    {
        return Ok(await addressService.Town(cityCode, cancellationToken));
    }
}
