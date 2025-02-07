using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Addresses.WebAPI.Models;

public class Entity
{
    [BsonId]
    [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string? Name { get; set; }

    [BsonElement("code"), BsonRepresentation(BsonType.String)]
    public string? Code { get; set; }
}
