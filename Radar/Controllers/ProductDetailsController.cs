using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Radar.Data.Models;

namespace Radar.Controllers
{
    public class ProductDetailsController : ApiController
    {
        private CompanyContext db = new CompanyContext();

        // GET: api/ProductDetails
        public IQueryable<ProductDetails> GetProductDetails()
        {
            return db.ProductDetails;
        }

        // GET: api/ProductDetails/5
        [ResponseType(typeof(ProductDetails))]
        public IHttpActionResult GetProductDetails(int id)
        {
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            return Ok(productDetails);
        }

        // PUT: api/ProductDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductDetails(int id, ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDetails.ProductID)
            {
                return BadRequest();
            }

            db.Entry(productDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailsExists(id))
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

        // POST: api/ProductDetails
        [ResponseType(typeof(ProductDetails))]
        public IHttpActionResult PostProductDetails(ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductDetails.Add(productDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productDetails.ProductID }, productDetails);
        }

        // DELETE: api/ProductDetails/5
        [ResponseType(typeof(ProductDetails))]
        public IHttpActionResult DeleteProductDetails(int id)
        {
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            db.ProductDetails.Remove(productDetails);
            db.SaveChanges();

            return Ok(productDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductDetailsExists(int id)
        {
            return db.ProductDetails.Count(e => e.ProductID == id) > 0;
        }
    }
}