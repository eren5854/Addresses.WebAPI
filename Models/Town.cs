using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Addresses.WebAPI.Models;

public sealed class Town : Entity
{
    [BsonElement("cityCode"), BsonRepresentation(BsonType.String)]
    public string? CityCode { get; set; }
}
