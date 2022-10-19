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
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    public class StorageController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Storage
        [ResponseType(typeof(List<StorageModel>))]
        public IHttpActionResult GetStorage()
        {
            return Ok(db.Storage.ToList().ConvertAll(x => new StorageModel(x)));
        }

        // GET: api/Storage/5
        [ResponseType(typeof(Storage))]
        public IHttpActionResult GetStorage(int id)
        {
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return NotFound();
            }

            return Ok(storage);
        }

        // PUT: api/Storage/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStorage(int id, Storage storage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storage.id_good)
            {
                return BadRequest();
            }

            db.Entry(storage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(id))
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

        // POST: api/Storage
        [ResponseType(typeof(Storage))]
        public IHttpActionResult PostStorage(Storage storage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Storage.Add(storage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = storage.id_good }, storage);
        }

        // DELETE: api/Storage/5
        [ResponseType(typeof(Storage))]
        public IHttpActionResult DeleteStorage(int id)
        {
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return NotFound();
            }

            db.Storage.Remove(storage);
            db.SaveChanges();

            return Ok(storage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StorageExists(int id)
        {
            return db.Storage.Count(e => e.id_good == id) > 0;
        }
    }
}