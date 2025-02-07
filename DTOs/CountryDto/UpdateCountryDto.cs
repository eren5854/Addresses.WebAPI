namespace Addresses.WebAPI.DTOs.CountryDto;

public sealed record UpdateCountryDto(
    string Id,
    string Name,
    string Code);
