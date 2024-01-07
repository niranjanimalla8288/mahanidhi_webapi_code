using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadpositionController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public LeadpositionController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadpositionDTO>>> GetLeadposition()
        {
            if (_context.LeadPositions == null)
            {
                return NotFound();
            }
            //return await _context.Add.ToListAsync();
            var Leadposition = await _context.LeadPositions.ToListAsync();
            List<LeadpositionDTO> lstLeadpositionDTO = new List<LeadpositionDTO>();
            lstLeadpositionDTO = _mapper.Map<List<LeadpositionDTO>>(Leadposition);
            return lstLeadpositionDTO;
        }
        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadposition(int id, LeadpositionDTO leadpositionDTO)
        {
            if (id != leadpositionDTO.Id)
            {
                return BadRequest();
            }
            LeadPosition leadPosition = _mapper.Map<LeadPosition>(leadpositionDTO);
            if (leadPosition != null)
                _context.Entry(leadPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadpositionExisting(id))
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

        private bool LeadpositionExisting(int id)
        {
            throw new NotImplementedException();
        }
        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LeadPosition>> PostLeadposition(LeadpositionDTO leadpositionDTO)
        {
            if (_context.LeadPositions == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.Leadpositons'  is null.");
            }
            LeadPosition leadPosition = _mapper.Map<LeadPosition>(leadpositionDTO);
            _context.LeadPositions.Add(leadPosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeadposition", new { id = leadPosition.Id }, leadPosition);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadposition(int id)
        {
            if (_context.LeadPositions == null)
            {
                return NotFound();
            }
            var leadposition = await _context.LeadPositions.FindAsync(id);
            if (leadposition == null)
            {
                return NotFound();
            }

            _context.LeadPositions.Remove(leadposition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadpositionExistinging(int id)
        {
            return (_context.Adds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
