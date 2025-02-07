using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Addresses.WebAPI.Models;

public sealed class City : Entity
{
    [BsonElement("countryCode"), BsonRepresentation(BsonType.String)]
    public string? CountryCode { get; set; }
}
