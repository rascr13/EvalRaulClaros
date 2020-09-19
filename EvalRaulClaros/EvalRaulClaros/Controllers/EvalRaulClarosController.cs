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
using EvalRaulClaros.Models;

namespace EvalRaulClaros.Controllers
{
    public class EvalRaulClarosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/EvalRaulClaros
        public IQueryable<EvalClaros> GetEvalRaulClaros()
        {
            return db.EvalRaulClaros;
        }

        // GET: api/EvalRaulClaros/5
        [ResponseType(typeof(EvalRaulClaros))]
        public IHttpActionResult GetEvalRaulClaros(string id)
        {
            EvalRaulClaros evalRaulClaros = db.EvalRaulClaros.Find(id);
            if (evalRaulClaros == null)
            {
                return NotFound();
            }

            return Ok(evalRaulClaros);
        }

        // PUT: api/EvalRaulClaros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvalRaulClaros(string id, EvalRaulClaros evalRaulClaros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evalRaulClaros.Name)
            {
                return BadRequest();
            }

            db.Entry(evalRaulClaros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvalRaulClarosExists(id))
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

        // POST: api/EvalRaulClaros
        [ResponseType(typeof(EvalRaulClaros))]
        public IHttpActionResult PostEvalRaulClaros(EvalRaulClaros evalRaulClaros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EvalRaulClaros.Add(evalRaulClaros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EvalRaulClarosExists(evalRaulClaros.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = evalRaulClaros.Name }, evalRaulClaros);
        }

        // DELETE: api/EvalRaulClaros/5
        [ResponseType(typeof(EvalRaulClaros))]
        public IHttpActionResult DeleteEvalRaulClaros(string id)
        {
            EvalRaulClaros evalRaulClaros = db.EvalRaulClaros.Find(id);
            if (evalRaulClaros == null)
            {
                return NotFound();
            }

            db.EvalRaulClaros.Remove(evalRaulClaros);
            db.SaveChanges();

            return Ok(evalRaulClaros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvalRaulClarosExists(string id)
        {
            return db.EvalRaulClaros.Count(e => e.Name == id) > 0;
        }
    }
}