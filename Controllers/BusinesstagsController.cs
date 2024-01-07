using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinesstagsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;

        public BusinesstagsController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      

        // GET: api/Businesstags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinesstagDTO>>> s()
        {
          if (_context.Businesstags == null)
          {
              return NotFound();
          }

            var businesstags= await _context.Businesstags.ToListAsync();
            List<BusinesstagDTO> lstBusinesstagDTO = new List<BusinesstagDTO>();
            lstBusinesstagDTO = _mapper.Map<List<BusinesstagDTO>>(businesstags);
            return lstBusinesstagDTO;
        }

        // GET: api/Businesstags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinesstagDTO>> GetBusinesstag(int id)
        {
          if (_context.Businesstags == null)
          {
              return NotFound();
          }
            var businesstag = await _context.Businesstags.FindAsync(id);
            BusinesstagDTO businesstagDTO = _mapper.Map<BusinesstagDTO>(businesstag);

            if (businesstag == null)
            {
                return NotFound();
            }

            return businesstagDTO;
        }

        // PUT: api/Businesstags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinesstag(int id, BusinesstagDTO businesstagDTO)
        {
            if (id != businesstagDTO.Id)

            {
                return BadRequest();
            }
            Businesstag businesstag = _mapper.Map<Businesstag>(businesstagDTO);
            if (businesstag != null)
                _context.Entry(businesstag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinesstagExists(id))
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

        // POST: api/Businesstags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BusinesstagDTO>> PostBusinesstag(BusinesstagDTO businesstagDTO)
        {
          if (businesstagDTO == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Businesstags'  is null.");
          }
            Businesstag businesstag = _mapper.Map<Businesstag>(businesstagDTO);
            _context.Businesstags.Add(businesstag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinesstag", new { id = businesstag.Id }, businesstag);
        }

        // DELETE: api/Businesstags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinesstag(int id)
        {
            if (_context.Businesstags == null)
            {
                return NotFound();
            }
            var businesstag = await _context.Businesstags.FindAsync(id);
            if (businesstag == null)
            {
                return NotFound();
            }

            _context.Businesstags.Remove(businesstag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinesstagExists(int id)
        {
            return (_context.Businesstags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
