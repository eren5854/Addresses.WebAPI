using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Addresses.WebAPI.Models;

public sealed class Town : Entity
{
    [BsonElement("cityId"), BsonRepresentation(BsonType.ObjectId)]
    public Guid CityId { get; set; }
    public City City { get; set; } = default!;
}
