using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MahaanidhiWebAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using MahaanidhiWebAPI.InputDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static MahaanidhiWebAPI.Mappers.GlobalMapper;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BadgesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;

        public BadgesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Badges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BadgeDTO>>> GetBadges()
        {
            if (_context.Badges == null)
            {
                return NotFound();
            }
            var badges = await _context.Badges.ToListAsync();
            List<BadgeDTO> lstBadgeDTO = new List<BadgeDTO>();
            lstBadgeDTO = _mapper.Map<List<BadgeDTO>>(badges);
            return lstBadgeDTO;
        }

        // GET: api/Badges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BadgeDTO>> GetBadge(int id)
        {
          if (_context.Badges == null)
          {
              return NotFound();
          }
            var badge = await _context.Badges.FindAsync(id);
            BadgeDTO badgeDTO = _mapper.Map <BadgeDTO>(badge);

            //MyOwnClass myOwnClass = _mapper.Map<MyOwnClass>(badge);

            if (badge == null)
            {
                return NotFound();
            }

            return badgeDTO;
        }

        // PUT: api/Badges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBadge(int id, BadgeDTO badgeDTO)
        {
            if (id != badgeDTO.Id)
            {
                return BadRequest();
            }

            Badge badge = _mapper.Map<Badge>(badgeDTO);
            if (badge != null)
            _context.Entry(badge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadgeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }           }

            return NoContent();
        }

        // POST: api/Badges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BadgeDTO>> PostBadge(BadgeDTO badgeDTO)
        {
          if (badgeDTO == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Badges'  is null.");
          }
            Badge badge= _mapper.Map<Badge>(badgeDTO);
           _context.Badges.Add(badge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBadge", new { id = badge.Id }, badge);
        }

        // DELETE: api/Badges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBadge(int id)
        {
            if (_context.Badges == null)
            {
                return NotFound();
            }
            var badge = await _context.Badges.FindAsync(id);
            if (badge == null)
            {
                return NotFound();
            }

            _context.Badges.Remove(badge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BadgeExists(int id)
        {
            return (_context.Badges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
