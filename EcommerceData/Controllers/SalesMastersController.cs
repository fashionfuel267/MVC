using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceData.Models;

namespace EcommerceData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesMastersController : ControllerBase
    {
        private readonly EModel _context;

        public SalesMastersController(EModel context)
        {
            _context = context;
        }

        // GET: api/SalesMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesMaster>>> GetSalesMasters()
        {
            return await _context.SalesMasters.ToListAsync();
        }

        // GET: api/SalesMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesMaster>> GetSalesMaster(int id)
        {
            var salesMaster = await _context.SalesMasters.FindAsync(id);

            if (salesMaster == null)
            {
                return NotFound();
            }

            return salesMaster;
        }

        // PUT: api/SalesMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesMaster(int id, SalesMaster salesMaster)
        {
            if (id != salesMaster.ID)
            {
                return BadRequest();
            }

            _context.Entry(salesMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesMasterExists(id))
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

        // POST: api/SalesMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalesMaster>> PostSalesMaster(SalesMaster salesMaster)
        {
            _context.SalesMasters.Add(salesMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesMaster", new { id = salesMaster.ID }, salesMaster);
        }

        // DELETE: api/SalesMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesMaster>> DeleteSalesMaster(int id)
        {
            var salesMaster = await _context.SalesMasters.FindAsync(id);
            if (salesMaster == null)
            {
                return NotFound();
            }

            _context.SalesMasters.Remove(salesMaster);
            await _context.SaveChangesAsync();

            return salesMaster;
        }

        private bool SalesMasterExists(int id)
        {
            return _context.SalesMasters.Any(e => e.ID == id);
        }
    }
}
