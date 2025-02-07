using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Addresses.WebAPI.Models;

public sealed class City : Entity
{
    [BsonElement("countryId"), BsonRepresentation(BsonType.ObjectId)]
    public Guid CountryId { get; set; }
    public Country Country { get; set; } = default!;
}
