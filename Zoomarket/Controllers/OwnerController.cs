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
    public class OwnerController : ApiController
    {
        ZooDbContext db = new ZooDbContext();

        // GET api/owner
        [ActionName("get"), HttpGet]
        public IEnumerable<Owner> OwnersList()
        {
            return db.Owners.ToList();
        }

        // GET api/owner/5
        public Owner Get(int id)
        {
            return db.Owners.Find(id);
        }

        // POST api/owner
        public HttpResponseMessage Post(Owner model)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(model);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/owner/5
        public HttpResponseMessage Put(Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owner).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, owner);
                return response;
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/owner/5
        public HttpResponseMessage Delete(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Owners.Remove(owner);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, owner);
        }
    }
}