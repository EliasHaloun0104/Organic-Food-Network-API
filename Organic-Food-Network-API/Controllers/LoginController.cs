using Newtonsoft.Json;
using Organic_Food_Network_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Organic_Food_Network_API.Controllers
{
    public class LoginController : ApiController
    {
        private Entities db = new Entities();

        // POST: api/Login
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            var json = JsonConvert.SerializeObject(person);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var res = await db.People.Where(p => p.Name == person.Name && p.Password == person.Password).FirstOrDefaultAsync();
            if(res == null)
                return Ok("Username or password doesn't match");

            return CreatedAtRoute("DefaultApi", new { id = res.Id }, res);
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