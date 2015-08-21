using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ShopMVCAPINew.App {
    public class MongoDbContext {

        public static MongoDbContext Instance = new MongoDbContext();
        // ds035553.mongolab.com:35553/appharbor_4qwprlcf -u kangwl -p abc123
        //mongodb://<dbuser>:<dbpassword>@ds035553.mongolab.com:35553/appharbor_4qwprlcf
        private readonly string _mongoConnUri = string.Format(
            "mongodb://{0}:{1}@ds035553.mongolab.com:35553/appharbor_4qwprlcf",
            "kangwl",
            "abc123"
            );

        private const string DefaultDb = "appharbor_4qwprlcf";

        //public Task InsertOne<T>(string collectionName, T bsonDocument) {
        //    var productColl = GetDBCollection<T>(collectionName);
        //    return productColl.InsertOneAsync(bsonDocument);
        //}

        //public Task<T> GetOne<T>(string collectionName, FilterDefinition<T> filterDefinition) {
        //    var productColl = GetDBCollection<T>(collectionName);
        //    return productColl.Find(filterDefinition).FirstOrDefaultAsync();
        //}

        //public Task<List<T>> GetMany<T>(string collectionName, FilterDefinition<T> filterDefinition) {
        //    var productColl = GetDBCollection<T>(collectionName);

        //    return productColl.Find(filterDefinition).ToListAsync();
        //}

        //public Task GetMany(string collectionName, FilterDefinition<BsonDocument> filterDefinition,
        //    Action<BsonDocument, int> action) {
        //    //like query
        //    //BsonDocument document=new BsonDocument("Name",new BsonRegularExpression("HONG"));
        //    var productColl = GetDBCollection<BsonDocument>(collectionName);
        //    return productColl.Find(filterDefinition).ForEachAsync(action);
        //}


        //public Task<UpdateResult> UpdateOne(string collectionName, FilterDefinition<BsonDocument> filterDefinition, UpdateDefinition<BsonDocument> updateDefinition) {
        //    var productColl = GetDBCollection<BsonDocument>(collectionName);
        //    Task<UpdateResult> updateTask = productColl.UpdateOneAsync(filterDefinition, updateDefinition);
        //    //if (updateTask.Result.IsModifiedCountAvailable) {
        //    //    long effectCount = updateTask.Result.ModifiedCount;
        //    //}
        //    return updateTask;
        //}


        /// <summary>
        /// 获取 MongoClient
        /// </summary>
        /// <returns></returns>
        public MongoClient GetMongoClient() {
            var client = new MongoDB.Driver.MongoClient(_mongoConnUri);
            return client;
        }

        public IMongoDatabase GetMongoDB() {
            var client = GetMongoClient();
            
            var mongoDB = client.GetDatabase(DefaultDb);
            return mongoDB;
        }

        public IMongoCollection<T> GetDBCollection<T>(string collectionName) {
            IMongoDatabase mongoDatabase = GetMongoDB();

            return mongoDatabase.GetCollection<T>(collectionName);
        }

    }
}