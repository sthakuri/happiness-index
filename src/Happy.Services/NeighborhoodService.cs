using Happy.EFCore;
using Happy.EFCore.Models;
using Happy.Services.Interfaces;
using Happy.ViewModels;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Happy.Services
{
    public class NeighborhoodService(HappyDbContext dbContext, IMongoDatabase mongoDb) : INeighborhoodService
    {
        HappyDbContext HappyDb = dbContext;
        private readonly IMongoCollection<BsonDocument> _nghCollection = mongoDb.GetCollection<BsonDocument>("SFNeighborhood");
        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllAsync()
        {
            return await HappyDb.Neighborhoods
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAllByZipCodeAsync(string zipCode)
        {
            return await HappyDb.Neighborhoods
                .Where(x => x.ZipCode == zipCode)
                .GroupBy(x => x.NeighborhoodName)
                .Select(x => new NeighborhoodViewModel()
                {
                    NeighborhoodName = x.Key
                })
                .ToListAsync();
        }

        public async Task<string> GetGeoJSONAsync()
        {
            var projection = Builders<BsonDocument>.Projection.Exclude("_id");

            var doc = await _nghCollection.Find(Builders<BsonDocument>.Filter.Empty)
                    .Project(projection)
                   .FirstOrDefaultAsync();

            return doc.ToJson();
        }
    }
}
