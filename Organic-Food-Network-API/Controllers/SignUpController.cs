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
    public class SignUpController : ApiController
    {
        private Entities db = new Entities();

        // POST: api/SignUp
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            Debug.WriteLine("HelloWorld!");
            var json = JsonConvert.SerializeObject(person);
            Debug.WriteLine(json.ToString());

            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (NameExist(person.Name))
            {
                return Ok("Name already Exist");
            }

            db.People.Add(person);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        private bool NameExist(string name)
        {
            return db.People.Count(e => (e.Name == name)) > 0;
        }
    }
}