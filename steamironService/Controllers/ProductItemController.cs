using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using steamironService.DataObjects;
using steamironService.Models;

namespace steamironService.Controllers
{
    public class ProductItemController : TableController<ProductItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            steamironContext context = new steamironContext();
            DomainManager = new EntityDomainManager<ProductItem>(context, Request);
        }

        // GET tables/ProductItem
        public IQueryable<ProductItem> GetAllProductItems()
        {
            return Query();
        }

        // GET tables/ProductItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ProductItem> GetProductItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ProductItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ProductItem> PatchProductItem(string id, Delta<ProductItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/ProductItem
        public async Task<IHttpActionResult> PostProductItem(ProductItem item)
        {
            ProductItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ProductItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteProductItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}