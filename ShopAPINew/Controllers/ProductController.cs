using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData.Query;
using ShopMVCAPINew.App;

namespace ShopMVCAPINew.Controllers
{
    public class ProductController : ApiController {

      
        /// <summary>
        /// 获取产品列表支持查询
        /// </summary>
        /// <returns>IEnumerable</returns>
        [Queryable
            (
                PageSize = 10
                ,MaxSkip = Int32.MaxValue
                ,MaxTop = 20
                ,AllowedQueryOptions = AllowedQueryOptions.OrderBy|AllowedQueryOptions.Skip|AllowedQueryOptions.Top|AllowedQueryOptions.InlineCount
                ,AllowedOrderByProperties = "ID"
                ,MaxNodeCount = 20
                ,AllowedFunctions = AllowedFunctions.None
            )
        ]
        public IEnumerable<Models.Product> Get() {
            return DataContext.Instance.Products.AsEnumerable();
        }

        /// <summary>
        /// 获取产品分页
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<Models.Product> GetProducts(int pagesize, int pageindex) {
            if (pagesize > 1000) {
                throw new Exception("pagesize 不能大于1000");
            }
            return DataContext.Instance.Products.OrderBy(p => p.ID).Skip(pagesize*pageindex).Take(pagesize);
        }

        // GET api/product/5
        public Models.Product Get(int id) {
            return DataContext.Instance.Products.FirstOrDefault(p => p.ID == id);
        }

        // POST api/product
        public bool Post([FromBody]Models.Product product) {
            DataContext.Instance.Entry(product).State=EntityState.Added;
            int changes = DataContext.Instance.SaveChanges();
            return changes > 0;
        }

        // PUT api/product/5
        public bool Put([FromBody] Models.Product product) {
            
            var oriProduct = DataContext.Instance.Products.FirstOrDefault(p => p.ID == product.ID);
            if (oriProduct == null) {
                throw new Exception("该产品不存在");
            }
            oriProduct.Name = product.Name;
            // DataContext.Instance.Entry(oriProduct).CurrentValues.SetValues(product);
            int changes = DataContext.Instance.SaveChanges();
            return changes > 0;
        }

        // DELETE api/product/5
        public bool Delete(int id) {
            var oriProduct = DataContext.Instance.Products.FirstOrDefault(p => p.ID == id);
            if (oriProduct == null) {
                throw new Exception("该产品不存在");
            }
            DataContext.Instance.Products.Remove(oriProduct);
            int changes = DataContext.Instance.SaveChanges();
            return changes > 0;
        }
    }
}
