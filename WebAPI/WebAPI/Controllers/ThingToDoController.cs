using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingToDoController : ControllerBase
    {
        private readonly ThingsToDoDBContext _context;

        public ThingToDoController(ThingsToDoDBContext context)
        {
            _context = context;
        }

        // GET: api/ThingToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThingToDo>>> GetThingsToDo()
        {
            return await _context.ThingsToDo.ToListAsync();
        }

        // GET: api/ThingToDo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThingToDo>> GetThingToDo(int id)
        {
            var thingToDo = await _context.ThingsToDo.FindAsync(id);

            if (thingToDo == null)
            {
                return NotFound();
            }

            return thingToDo;
        }

        // PUT: api/ThingToDo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThingToDo(int id, ThingToDo thingToDo)
        {
            //if (id != thingToDo.Id)
            //{
            //    return BadRequest();
            //}
            thingToDo.Id = id;

            _context.Entry(thingToDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThingToDoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ThingToDo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ThingToDo>> PostThingToDo(ThingToDo thingToDo)
        {
            _context.ThingsToDo.Add(thingToDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThingToDo", new { id = thingToDo.Id }, thingToDo);
        }

        // DELETE: api/ThingToDo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThingToDo>> DeleteThingToDo(int id)
        {
            var thingToDo = await _context.ThingsToDo.FindAsync(id);
            if (thingToDo == null)
            {
                return NotFound();
            }

            _context.ThingsToDo.Remove(thingToDo);
            await _context.SaveChangesAsync();

            return thingToDo;
        }

        private bool ThingToDoExists(int id)
        {
            return _context.ThingsToDo.Any(e => e.Id == id);
        }
    }
}
