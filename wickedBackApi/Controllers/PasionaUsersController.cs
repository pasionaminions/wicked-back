using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wickedBackApi.Models;

namespace wickedBackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasionaUsersController : ControllerBase
    {
        private readonly Context _context;

        public PasionaUsersController(Context context)
        {
            _context = context;
        }

        // GET: api/PasionaUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasionaUser>>> GetPasionaUser()
        {
            return await _context.PasionaUser.ToListAsync();
        }

        // GET: api/PasionaUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PasionaUser>> GetPasionaUser(int id)
        {
            var pasionaUser = await _context.PasionaUser.FindAsync(id);

            if (pasionaUser == null)
            {
                return NotFound();
            }

            return pasionaUser;
        }

        // PUT: api/PasionaUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasionaUser(int id, PasionaUser pasionaUser)
        {
            if (id != pasionaUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(pasionaUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasionaUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPasionaUser", new { id = pasionaUser.Id }, pasionaUser);
        }

        // POST: api/PasionaUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PasionaUser>> PostPasionaUser(PasionaUser pasionaUser)
        {
            _context.PasionaUser.Add(pasionaUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasionaUser", new { id = pasionaUser.Id }, pasionaUser);
        }

        // DELETE: api/PasionaUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PasionaUser>> DeletePasionaUser(int id)
        {
            var pasionaUser = await _context.PasionaUser.FindAsync(id);
            if (pasionaUser == null)
            {
                return NotFound();
            }

            _context.PasionaUser.Remove(pasionaUser);
            await _context.SaveChangesAsync();

            return pasionaUser;
        }

        private bool PasionaUserExists(int id)
        {
            return _context.PasionaUser.Any(e => e.Id == id);
        }
    }
}
