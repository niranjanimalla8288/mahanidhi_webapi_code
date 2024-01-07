using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MahaanidhiWebAPI.Entities;
using AutoMapper;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Authorization;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceproviderreviewsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceproviderreviewsController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceproviderreviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceproviderreviewDTO>>> GetServiceproviderreviews()
        {
          if (_context.Serviceproviderreviews == null)
          {
              return NotFound();
          }
            //return await _context.Serviceproviderreviews.ToListAsync();
            var serviceproviderreviews = await _context.Serviceproviderreviews.ToListAsync();
            List<ServiceproviderreviewDTO> lstServiceproviderreviewDTO = new List<ServiceproviderreviewDTO>();
            lstServiceproviderreviewDTO = _mapper.Map<List<ServiceproviderreviewDTO>>(serviceproviderreviews);
            return lstServiceproviderreviewDTO;
        }

        // GET: api/Serviceproviderreviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceproviderreviewDTO>> GetServiceproviderreview(int id)
        {
          if (_context.Serviceproviderreviews == null)
          {
              return NotFound();
          }
            var serviceproviderreview = await _context.Serviceproviderreviews.FindAsync(id);
            ServiceproviderreviewDTO serviceproviderreviewDTO = _mapper.Map<ServiceproviderreviewDTO>(serviceproviderreview);
            if (serviceproviderreview == null)
            {
                return NotFound();
            }

            return serviceproviderreviewDTO;
        }

        // PUT: api/Serviceproviderreviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceproviderreview(int id, ServiceproviderreviewDTO serviceproviderreviewDTO)
        {
            if (id != serviceproviderreviewDTO.Id)
            {
                return BadRequest();
            }
            Serviceproviderreview serviceproviderreview = _mapper.Map<Serviceproviderreview>(serviceproviderreviewDTO);
            if (serviceproviderreview != null)
                _context.Entry(serviceproviderreview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceproviderreviewExists(id))
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

        // POST: api/Serviceproviderreviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceproviderreviewDTO>> PostServiceproviderreview(ServiceproviderreviewDTO serviceproviderreviewDTO)
        {
          if (_context.Serviceproviderreviews == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Serviceproviderreviews'  is null.");
          }
            Serviceproviderreview serviceproviderreview = _mapper.Map<Serviceproviderreview>(serviceproviderreviewDTO);
            _context.Serviceproviderreviews.Add(serviceproviderreview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceproviderreview", new { id = serviceproviderreview.Id }, serviceproviderreview);
        }

        // DELETE: api/Serviceproviderreviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceproviderreview(int id)
        {
            if (_context.Serviceproviderreviews == null)
            {
                return NotFound();
            }
            var serviceproviderreview = await _context.Serviceproviderreviews.FindAsync(id);
            if (serviceproviderreview == null)
            {
                return NotFound();
            }

            _context.Serviceproviderreviews.Remove(serviceproviderreview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceproviderreviewExists(int id)
        {
            return (_context.Serviceproviderreviews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
