using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ADProj.DB;
using ADProj.Models;

namespace ADProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomEmployeeMobilesController : ControllerBase
    {
        private readonly ADProjContext _context;

        public CustomEmployeeMobilesController(ADProjContext context)
        {
            _context = context;
        }

        // GET: api/CustomEmployeeMobiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomEmployeeMobile>>> GetCustomEmployeeMobile()
        {
            return await _context.CustomEmployeeMobile.ToListAsync();
        }

        // GET: api/CustomEmployeeMobiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomEmployeeMobile>> GetCustomEmployeeMobile(int id)
        {
            var customEmployeeMobile = await _context.CustomEmployeeMobile.FindAsync(id);

            if (customEmployeeMobile == null)
            {
                return NotFound();
            }

            return customEmployeeMobile;
        }

        // PUT: api/CustomEmployeeMobiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomEmployeeMobile(int id, CustomEmployeeMobile customEmployeeMobile)
        {
            if (id != customEmployeeMobile.Id)
            {
                return BadRequest();
            }

            _context.Entry(customEmployeeMobile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomEmployeeMobileExists(id))
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

        // POST: api/CustomEmployeeMobiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomEmployeeMobile>> PostCustomEmployeeMobile(CustomEmployeeMobile customEmployeeMobile)
        {
            _context.CustomEmployeeMobile.Add(customEmployeeMobile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomEmployeeMobile", new { id = customEmployeeMobile.Id }, customEmployeeMobile);
        }

        // DELETE: api/CustomEmployeeMobiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomEmployeeMobile>> DeleteCustomEmployeeMobile(int id)
        {
            var customEmployeeMobile = await _context.CustomEmployeeMobile.FindAsync(id);
            if (customEmployeeMobile == null)
            {
                return NotFound();
            }

            _context.CustomEmployeeMobile.Remove(customEmployeeMobile);
            await _context.SaveChangesAsync();

            return customEmployeeMobile;
        }

        private bool CustomEmployeeMobileExists(int id)
        {
            return _context.CustomEmployeeMobile.Any(e => e.Id == id);
        }
    }
}
