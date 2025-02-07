namespace Addresses.WebAPI.DTOs.CountryDto;

public sealed record CreateCountryDto(
    string Name,
    string Code);