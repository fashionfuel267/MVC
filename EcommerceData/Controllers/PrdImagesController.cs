using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceData.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;

namespace EcommerceData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrdImagesController : ControllerBase
    {
        private readonly EModel _context;
        private readonly IWebHostEnvironment _env;

        public PrdImagesController(EModel context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this._env = hostingEnvironment;
        }

        // GET: api/PrdImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrdImage>>> GetPrdImages()
        {
            return await _context.PrdImages.ToListAsync();
        }

        // GET: api/PrdImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrdImage>> GetPrdImage(int id)
        {
            var prdImage = await _context.PrdImages.FindAsync(id);

            if (prdImage == null)
            {
                return NotFound();
            }

            return prdImage;
        }

        // PUT: api/PrdImages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrdImage(int id, PrdImage prdImage)
        {
            if (id != prdImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(prdImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrdImageExists(id))
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

        // POST: api/PrdImages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<PrdImage>> PostPrdImage(PrdImage prdImage)
        //{
        //    _context.PrdImages.Add(prdImage);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPrdImage", new { id = prdImage.Id }, prdImage);
        //}
        //public async Task<ActionResult<PrdImage>> PostPrdImage(PrdImage prdImage)
        public IActionResult PostPrdImage()
        {
            try
            {
                var httpreq = HttpContext.Request.Body;
                var pid = Request.Form["Pid"].ToString();
                var file = Request.Form.Files[0];
                string rootPtah = Path.Combine(this._env.WebRootPath, "ProductImage");

                if (!Directory.Exists(rootPtah))
                {
                    Directory.CreateDirectory(rootPtah);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string ext = Path.GetExtension(fileName);
                    string filewithoutext = Path.GetFileNameWithoutExtension(fileName);
                    string filepath = Path.Combine(rootPtah, (filewithoutext + "_" + pid + ext));
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    
                    string imagePath = "/ProductImage/" + filewithoutext + "_" + pid + ext;
                    var prd = new PrdImage
                    {
                       
                        ProductId=Int32.Parse( pid),

                    OriginalImagePath=imagePath,                        
                    };
                    _context.PrdImages.Add(prd);
                    if ( _context.SaveChanges() > 0)
                    {
                        return Created("api/PrdImages", prd);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            // return Ok(new { resul = "Successfuly created" });
            return BadRequest();
        }
        // DELETE: api/PrdImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrdImage>> DeletePrdImage(int id)
        {
            var prdImage = await _context.PrdImages.FindAsync(id);
            if (prdImage == null)
            {
                return NotFound();
            }

            _context.PrdImages.Remove(prdImage);
            await _context.SaveChangesAsync();

            return prdImage;
        }

        private bool PrdImageExists(int id)
        {
            return _context.PrdImages.Any(e => e.Id == id);
        }
    }
}
