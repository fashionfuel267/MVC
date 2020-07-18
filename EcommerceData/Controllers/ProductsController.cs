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
    public class ProductsController : ControllerBase
    {
        private readonly EModel _context;

        public ProductsController(EModel context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        public System.Object GetProducts()
        {
            var list = (from o in _context.Products
                                    join c in _context.PrdImages on o.Id equals c.ProductId
                                   
                                    select new
                                    {

                                        o.Name,
                                        o.ProductDescription,
                                        o.SalesPrice,
                                        o.PurchasePrice,
                                        o.UnitName,
                                        ImagePath = c.OriginalImagePath,
                                        o.Id
                                    }).ToList();
            //return await _context.Products.ToListAsync();
            return list;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        public   System.Object GetProduct(int id)
        {
            //var product = await _context.Products.FindAsync(id);

            //if (product == null)
            //{
            //    return NotFound();
            //}
            var product = (from o in  _context.Products
                        join c in  _context.PrdImages on o.Id equals c.ProductId
                        where o.Id ==id
                        select new
                        {

                            o.Name,
                            o.ProductDescription,
                            o.SalesPrice,
                            o.PurchasePrice,
                            o.UnitName,
                            ImagePath = c.OriginalImagePath,
                            o.Id
                        }).SingleOrDefault();
            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            //_context.Products.Add(product);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            try
            {
                if (product.Id > 0)
                {
                    _context.Entry(product).State = EntityState.Modified;

                }
                else
                {
                    _context.Products.Add(product);
                }
                await _context.SaveChangesAsync();
                return Ok(product);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
