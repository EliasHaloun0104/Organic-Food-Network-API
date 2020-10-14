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
using Organic_Food_Network_API.Models;

namespace Organic_Food_Network_API.Controllers
{
    public class ProductsByUserController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/ProductsByUser
        public IQueryable<Product> GetProducts(int id)
        {
            return db.Products.OrderByDescending(e => e.DateCreated).Where(e=> e.PersonID == id).Take(10);
        }

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }
}