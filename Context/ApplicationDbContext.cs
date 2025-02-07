using MongoDB.Driver;

namespace Addresses.WebAPI.Context;

public class ApplicationDbContext(IConfiguration configuration)
{
    private readonly IMongoDatabase _database = new MongoClient(MongoUrl.Create(configuration.GetConnectionString("MongoDb")))
        .GetDatabase(MongoUrl.Create(configuration.GetConnectionString("MongoDb")).DatabaseName);

    public IMongoDatabase? Database => _database;
}
