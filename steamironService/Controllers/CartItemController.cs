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
    public class CartItemController : TableController<CartItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            steamironContext context = new steamironContext();
            DomainManager = new EntityDomainManager<CartItem>(context, Request);
        }

        // GET tables/CartItem
        public IQueryable<CartItem> GetAllCartItem()
        {
            return Query();
        }

        // GET tables/CartItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CartItem> GetCartItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/CartItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CartItem> PatchCartItem(string id, Delta<CartItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/CartItem
        public async Task<IHttpActionResult> PostCartItem(CartItem cart)
        {
            CartItem current = await InsertAsync(cart);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/CartItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCartItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}