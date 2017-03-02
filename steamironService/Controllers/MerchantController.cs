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
    public class MerchantController : TableController<Merchant>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            steamironContext context = new steamironContext();
            DomainManager = new EntityDomainManager<Merchant>(context, Request);
        }

        // GET tables/Merchant
        public IQueryable<Merchant> GetAllMerchant()
        {
            return Query();
        }

        // GET tables/Merchant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Merchant> GetMerchant(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Merchant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Merchant> PatchMerchant(string id, Delta<Merchant> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Merchant
        public async Task<IHttpActionResult> PostCart(Merchant merchant)
        {
            Merchant current = await InsertAsync(merchant);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Merchant/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMerchant(string id)
        {
            return DeleteAsync(id);
        }
    }
}