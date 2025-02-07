namespace Addresses.WebAPI.DTOs.TownDto;

public sealed record CreateTownDto(
    string Name,
    string Code,
    string CityCode);
