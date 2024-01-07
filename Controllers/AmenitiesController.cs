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
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public AmenitiesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            //return await _context.Amenities.ToListAsync();
            var amenities = await _context.Amenities.ToListAsync();
            List<AmenityDTO> lstAmenityDTO = new List<AmenityDTO>();
            lstAmenityDTO = _mapper.Map<List<AmenityDTO>>(amenities);
            return lstAmenityDTO;
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
          if (_context.Amenities == null)
          {
              return NotFound();
          }
            var amenity = await _context.Amenities.FindAsync(id);
            AmenityDTO amenityDTO = _mapper.Map<AmenityDTO>(amenity);
            if (amenity == null)
            {
                return NotFound();
            }

            return amenityDTO;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, AmenityDTO amenityDTO)
        {
            if (id != amenityDTO.Id)
            {
                return BadRequest();
            }
            Amenity amenity = _mapper.Map<Amenity>(amenityDTO);
            if (amenity != null)
                _context.Entry(amenity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenityExists(id))
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

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Amenity>> PostAmenity(AmenityDTO amenityDTO)
        {
          if (_context.Amenities == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Amenities'  is null.");
          }
            Amenity amenity = _mapper.Map<Amenity>(amenityDTO);
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            if (_context.Amenities == null)
            {
                return NotFound();
            }
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }

            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmenityExists(int id)
        {
            return (_context.Amenities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
