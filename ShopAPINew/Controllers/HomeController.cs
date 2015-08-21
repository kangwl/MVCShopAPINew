using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ShopMVCAPINew.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            //Task task = App.MongoDbContext.Instance.InsertOne("Product", new BsonDocument() {
            //    {"Name", "HONGMI NOTE"}
            //});
            //task.Wait();
            //ViewBag.PCount = task.IsCompleted;


            
           // var productCollection = App.MongoDbContext.Instance.GetDBCollection<Models.Product>("Product");
           //var project= Builders<BsonDocument>.Projection.Exclude("_id");
           // var task = productCollection.Find(p => p.Name == "HONGMI NOTE").FirstOrDefaultAsync();
           // task.Wait();
           // if (task.IsCompleted) {
           //     var model = task.Result;
           // }

            //BsonDocument bson = task.Result;
            //ViewBag.PCount = bson.GetValue(0);

            //FilterDefinitionBuilder<BsonDocument> ft = new FilterDefinitionBuilder<BsonDocument>();
            //var f1 = ft.Eq("Name", new BsonRegularExpression("HONG"));

            //var t = App.MongoDbContext.Instance.GetMany("Product", f1, Ret);
            //t.Wait();

            return View();
        }

        private void Ret(BsonDocument arg1, int arg2) {
            Response.Write(arg1);
        }

    }
}
