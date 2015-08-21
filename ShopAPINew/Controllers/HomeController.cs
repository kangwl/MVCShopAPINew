using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ShopMVCAPINew.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            //Task task = App.MongoDBContext.Instance.Insert("Product", new BsonDocument() {
            //    {"Name", "HONGMI NOTE"}
            //});
            //task.Wait();
            //ViewBag.PCount = task.IsCompleted;
 
            

            //Task<BsonDocument> task = App.MongoDBContext.Instance.GetOne("Product", new BsonDocument("Name", "HONGMI NOTE"));

            //BsonDocument bson = task.Result;
            //ViewBag.PCount = bson.GetValue(0);

            //var productColl = App.MongoDBContext.Instance.GetDBCollection<BsonDocument>("Product");


            //var product1 = new BsonDocument() {
            //    {"Name","小米4"},
            //    {"Price","5000"},
            //    {"Color","Red"},
            //    {"Amount",300000}
            //};
            //var product2 = new BsonDocument() {
            //    {"Name","小米4"},
            //    {"Price","4900"},
            //    {"Color","blue"},
            //    {"Amount",200000}
            //};
            //var product3 = new BsonDocument() {
            //    {"Name","小米4"},
            //    {"Price","5100"},
            //    {"Color","white"},
            //    {"Amount",300000}
            //};
            //List<BsonDocument> docs = new List<BsonDocument>();
            //docs.Add(product1);
            //docs.Add(product2);
            //docs.Add(product3);
            //productColl.InsertManyAsync(docs).Wait();
           // productColl.InsertOneAsync(product).Wait();


            
            //FilterDefinitionBuilder<BsonDocument> ft = new FilterDefinitionBuilder<BsonDocument>();
            ////var bsonDoc = ft.Eq("Color", new BsonRegularExpression("white"));
            //var bsonDoc = ft.Eq("Name", "小米4");
            //ProjectionDefinitionBuilder<BsonDocument> pfb=new ProjectionDefinitionBuilder<BsonDocument>();
            //var pj1 = pfb.Exclude("_id");
            
            //productColl.Find(bsonDoc).Project(pj1).ForEachAsync((doc, index) => Response.Write(doc+"--"+index)).Wait();

            ViewBag.CurrentPage = "index";
            return View("Index");
        }
 
    }
}
