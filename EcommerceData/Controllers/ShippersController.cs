﻿using System;
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
    public class ShippersController : ControllerBase
    {
        private readonly EModel _context;

        public ShippersController(EModel context)
        {
            _context = context;
        }

        // GET: api/Shippers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipper>>> GetShippers()
        {
            return await _context.Shippers.ToListAsync();
        }

        // GET: api/Shippers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipper>> GetShipper(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);

            if (shipper == null)
            {
                return NotFound();
            }

            return shipper;
        }

        // PUT: api/Shippers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipper(int id, Shipper shipper)
        {
            if (id != shipper.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipperExists(id))
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

        // POST: api/Shippers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shipper>> PostShipper(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipper", new { id = shipper.Id }, shipper);
        }

        // DELETE: api/Shippers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shipper>> DeleteShipper(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper == null)
            {
                return NotFound();
            }

            _context.Shippers.Remove(shipper);
            await _context.SaveChangesAsync();

            return shipper;
        }

        private bool ShipperExists(int id)
        {
            return _context.Shippers.Any(e => e.Id == id);
        }
    }
}
