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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PersonasController : ApiController
    {
        private dbTestPersonaEntities db = new dbTestPersonaEntities();

        // GET: api/Personas/Listar
        [ActionName("Listar")]
        public IQueryable<Persona> GetPersona()
        {
            return db.Persona;
        }

        // GET: api/Personas/Buscar/5
        [ActionName("Buscar")]
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> GetPersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/Actualizar
        [HttpPut]
        [ActionName("Actualizar")]
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> PutPersona( Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(persona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(persona.idPersona))
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

        // POST: api/Personas/Crear
        [ActionName("Crear")]
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(persona);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaExists(persona.idPersona))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = persona.idPersona }, persona);
        }

        // DELETE: api/Personas/Eliminar/5
        [ActionName("Eliminar")]
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Persona.Remove(persona);
            await db.SaveChangesAsync();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Persona.Count(e => e.idPersona == id) > 0;
        }
      
        
        [ActionName("Test")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            string respuesta = "Hola Mundo ";
            return Ok(respuesta);
        }
    }
}