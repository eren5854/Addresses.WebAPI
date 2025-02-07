using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Addresses.WebAPI.Models;

public sealed class District : Entity
{
    [BsonElement("townId"), BsonRepresentation(BsonType.ObjectId)]
    public string? TownId { get; set; }
    public Town Town { get; set; } = default!;
}
