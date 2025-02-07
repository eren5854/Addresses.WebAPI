namespace Addresses.WebAPI.DTOs.CityDto;

public sealed record CreateCityDto(
    string Name,
    string Code,
    string CountryCode);