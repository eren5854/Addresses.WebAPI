namespace Addresses.WebAPI.DTOs.CityDto;

public sealed record UpdateCityDto(
    string Id,
    string Name,
    string Code,
    string CountryCode);
