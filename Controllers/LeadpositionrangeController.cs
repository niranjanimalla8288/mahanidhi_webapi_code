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
    public class LeadpositionrangeController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public LeadpositionrangeController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadpositionrangeDTO>>> GetLeadposition()
        {
            if (_context.LeadspositionRanges == null)
            {
                return NotFound();
            }
            //return await _context.Add.ToListAsync();
            var leadpositionRange = await _context.LeadspositionRanges.ToListAsync();
            List<LeadpositionrangeDTO> lstLeadpositionrangeDTO = new List<LeadpositionrangeDTO>();
            lstLeadpositionrangeDTO = _mapper.Map<List<LeadpositionrangeDTO>>(leadpositionRange);
            return lstLeadpositionrangeDTO;
        }
        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadposition(int id, LeadpositionrangeDTO leadpositionrangeDTO)
        {
            if (id != leadpositionrangeDTO.Id)
            {
                return BadRequest();
            }
            LeadspositionRange leadpositionrange = _mapper.Map<LeadspositionRange>(leadpositionrangeDTO);
            if (leadpositionrange != null)
                _context.Entry(leadpositionrange).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadpositionRangeExisting(id))
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

        private bool LeadpositionRangeExisting(int id)
        {
            throw new NotImplementedException();
        }
        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LeadspositionRange>> PostLeadpositionRange(LeadpositionrangeDTO leadpositionrangeDTO)
        {
            if (_context.LeadspositionRanges == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.leadpositionranges'  is null.");
            }
            LeadspositionRange leadpositionrange = _mapper.Map<LeadspositionRange>(leadpositionrangeDTO);
            _context.LeadspositionRanges.Add(leadpositionrange);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeadposition", new { id = leadpositionrange.Id }, leadpositionrange);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadpositionrange(int id)
        {
            if (_context.LeadspositionRanges == null)
            {
                return NotFound();
            }
            var leadpositionRange = await _context.LeadspositionRanges.FindAsync(id);
            if (leadpositionRange == null)
            {
                return NotFound();
            }

            _context.LeadspositionRanges.Remove(leadpositionRange);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadpositionExistingings(int id)
        {
            return (_context.LeadspositionRanges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
