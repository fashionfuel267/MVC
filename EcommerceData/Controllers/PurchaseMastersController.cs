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
    public class PurchaseMastersController : ControllerBase
    {
        private readonly EModel _context;

        public PurchaseMastersController(EModel context)
        {
            _context = context;
        }

        // GET: api/PurchaseMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseMaster>>> GetPurchaseMasters()
        {
            return await _context.PurchaseMasters.ToListAsync();
        }

        // GET: api/PurchaseMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseMaster>> GetPurchaseMaster(int id)
        {
            var purchaseMaster = await _context.PurchaseMasters.FindAsync(id);

            if (purchaseMaster == null)
            {
                return NotFound();
            }

            return purchaseMaster;
        }

        // PUT: api/PurchaseMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseMaster(int id, PurchaseMaster purchaseMaster)
        {
            if (id != purchaseMaster.ID)
            {
                return BadRequest();
            }

            _context.Entry(purchaseMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseMasterExists(id))
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

        // POST: api/PurchaseMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseMaster>> PostPurchaseMaster(PurchaseMaster purchaseMaster)
        {
            _context.PurchaseMasters.Add(purchaseMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseMaster", new { id = purchaseMaster.ID }, purchaseMaster);
        }

        // DELETE: api/PurchaseMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseMaster>> DeletePurchaseMaster(int id)
        {
            var purchaseMaster = await _context.PurchaseMasters.FindAsync(id);
            if (purchaseMaster == null)
            {
                return NotFound();
            }

            _context.PurchaseMasters.Remove(purchaseMaster);
            await _context.SaveChangesAsync();

            return purchaseMaster;
        }

        private bool PurchaseMasterExists(int id)
        {
            return _context.PurchaseMasters.Any(e => e.ID == id);
        }
    }
}
