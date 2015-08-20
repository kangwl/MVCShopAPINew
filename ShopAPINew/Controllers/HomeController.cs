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
            //Task task = App.MongoDBContext.Instance.Insert("Product", new BsonDocument() {
            //    {"Name", "HONGMI NOTE"}
            //});
            //task.Wait();
            //ViewBag.PCount = task.IsCompleted;
 
            

            //Task<BsonDocument> task = App.MongoDBContext.Instance.GetOne("Product", new BsonDocument("Name", "HONGMI NOTE"));

            //BsonDocument bson = task.Result;
            //ViewBag.PCount = bson.GetValue(0);

            FilterDefinitionBuilder<BsonDocument> ft = new FilterDefinitionBuilder<BsonDocument>();


            var t = App.MongoDBContext.Instance.GetMany("Product", ft.Eq("Name", ".*HONG.*"), Ret);
            t.Wait();

            return View();
        }

        private void Ret(BsonDocument arg1, int arg2) {
            Response.Write(arg1);
        }

    }
}
