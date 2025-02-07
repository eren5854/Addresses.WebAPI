namespace Addresses.WebAPI.DTOs.TownDto;

public sealed record UpdateTownDto(
    string Id,
    string Name,
    string Code,
    string CityCode);
