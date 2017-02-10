using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoomarket.Data;
using Zoomarket.Models;

namespace Zoomarket.Controllers
{
    public class PetController : ApiController
    {
        ZooDbContext db = new ZooDbContext();

        // GET api/pet
        [ActionName("get"), HttpGet]
        public IEnumerable<Pet> PetssList()
        {
            return db.Pets.ToList();
        }

        // GET api/pet/5
        public Pet Get(int id)
        {
            return db.Pets.Find(id);
        }

        // POST api/pet
        public HttpResponseMessage Post(Pet model)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(model);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/pet/5
        public HttpResponseMessage Put(Pet model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/pet/5
        public HttpResponseMessage Delete(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Pets.Remove(pet);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, pet);
        }
    }
}