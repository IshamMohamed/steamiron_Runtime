using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using steamironService.DataObjects;
using steamironService.Models;
using Microsoft.Azure.Mobile.Server.Config;

namespace steamironService.Controllers
{
    [MobileAppController]
    [RoutePrefix("api/ProductItem")]
    public class ProductItemsController : ApiController
    {
        private steamironContext db = new steamironContext();

        // GET: api/ProductItems
        [HttpGet]
        [Route("GetAllProductItems")]
        public IQueryable<ProductItem> GetProductItems()
        {
            ProductItemController prod = new ProductItemController();
            return db.ProductItems;
        }

        // GET: api/ProductItems/5
        [ResponseType(typeof(ProductItem))]
        public async Task<IHttpActionResult> GetProductItem(string id)
        {
            ProductItem productItem = await db.ProductItems.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }

            return Ok(productItem);
        }

        // PUT: api/ProductItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductItem(string id, ProductItem productItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productItem.Id)
            {
                return BadRequest();
            }

            db.Entry(productItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductItems
        [ResponseType(typeof(ProductItem))]
        public async Task<IHttpActionResult> PostProductItem(ProductItem productItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductItems.Add(productItem);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductItemExists(productItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productItem.Id }, productItem);
        }

        // DELETE: api/ProductItems/5
        [ResponseType(typeof(ProductItem))]
        public async Task<IHttpActionResult> DeleteProductItem(string id)
        {
            ProductItem productItem = await db.ProductItems.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }

            db.ProductItems.Remove(productItem);
            await db.SaveChangesAsync();

            return Ok(productItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductItemExists(string id)
        {
            return db.ProductItems.Count(e => e.Id == id) > 0;
        }
    }
}