using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ShopMVCAPINew.App {
    public class MongoDBContext {

        public static MongoDBContext Instance = new MongoDBContext();
        // ds035553.mongolab.com:35553/appharbor_4qwprlcf -u kangwl -p abc123
        //mongodb://<dbuser>:<dbpassword>@ds035553.mongolab.com:35553/appharbor_4qwprlcf
        private readonly string mongoConnUri = string.Format(
            "mongodb://{0}:{1}@ds035553.mongolab.com:35553/appharbor_4qwprlcf",
            "kangwl",
            "abc123"
            );

        private const string _defaultDB = "appharbor_4qwprlcf";

        public Task InsertOne(string collectionName, BsonDocument bsonDocument) {
            var productColl = GetDBCollection<BsonDocument>(collectionName);
            return productColl.InsertOneAsync(bsonDocument);
        }

        public Task<BsonDocument> GetOne(string collectionName, FilterDefinition<BsonDocument> filterDefinition) {
            var productColl = GetDBCollection<BsonDocument>(collectionName);
            return productColl.Find(filterDefinition).FirstOrDefaultAsync();
        }

        public Task<List<BsonDocument>> GetMany(string collectionName, FilterDefinition<BsonDocument> filterDefinition) {
            var productColl = GetDBCollection<BsonDocument>(collectionName);

            return productColl.Find(filterDefinition).ToListAsync();
        }

        public Task GetMany(string collectionName, FilterDefinition<BsonDocument> filterDefinition,
            Action<BsonDocument, int> action) {
            BsonDocument document=new BsonDocument("Name",new BsonRegularExpression("HONG"));
            var productColl = GetDBCollection<BsonDocument>(collectionName);
            return productColl.Find(document).ForEachAsync(action);
        }


        public Task<UpdateResult> UpdateOne(string collectionName, FilterDefinition<BsonDocument> filterDefinition, UpdateDefinition<BsonDocument> updateDefinition) {
            var productColl = GetDBCollection<BsonDocument>(collectionName);
            Task<UpdateResult> updateTask = productColl.UpdateOneAsync(filterDefinition, updateDefinition);
            //if (updateTask.Result.IsModifiedCountAvailable) {
            //    long effectCount = updateTask.Result.ModifiedCount;
            //}
            return updateTask;
        }





        /// <summary>
        /// 获取 MongoClient
        /// </summary>
        /// <returns></returns>
        public MongoClient GetMongoClient() {
            var client = new MongoDB.Driver.MongoClient(mongoConnUri);
            return client;
        }

        public IMongoDatabase GetMongoDB() {
            var client = GetMongoClient();
            
            var mongoDB = client.GetDatabase(_defaultDB);
            return mongoDB;
        }

        public IMongoCollection<T> GetDBCollection<T>(string collectionName) where T : class {
            IMongoDatabase mongoDatabase = GetMongoDB();

            return mongoDatabase.GetCollection<T>(collectionName);
        }

    }
}