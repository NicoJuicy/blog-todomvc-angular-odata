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
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using Odata_101.Models;

namespace Odata_101.Controllers
{
    public class NotesController : ODataController
    {
        private NoteContext db = new NoteContext();

        // GET: odata/Notes
        [EnableQuery]
        public IQueryable<Note> GetNotes()
        {
            return db.Notes;
        }

        // GET: odata/Notes(5)
        [EnableQuery]
        public SingleResult<Note> GetNote([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.Notes.Where(note => note.id == key));
        }

        // PUT: odata/Notes(5)
        public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<Note> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Note note = await db.Notes.FindAsync(key);
            if (note == null)
            {
                return NotFound();
            }

            patch.Put(note);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(note);
        }

        // POST: odata/Notes
        public async Task<IHttpActionResult> Post(Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notes.Add(note);
            await db.SaveChangesAsync();

            return Created(note);
        }

        // PATCH: odata/Notes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<Note> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Note note = await db.Notes.FindAsync(key);
            if (note == null)
            {
                return NotFound();
            }

            patch.Patch(note);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(note);
        }

        // DELETE: odata/Notes(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
        {
            Note note = await db.Notes.FindAsync(key);
            if (note == null)
            {
                return NotFound();
            }

            db.Notes.Remove(note);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoteExists(Guid key)
        {
            return db.Notes.Count(e => e.id == key) > 0;
        }
    }
}
