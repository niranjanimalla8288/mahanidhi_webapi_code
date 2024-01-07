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
    public class ServiceproviderbadgesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceproviderbadgesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceproviderbadges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceproviderbadgeDTO>>> GetServiceproviderbadges()
        {
          if (_context.Serviceproviderbadges == null)
          {
              return NotFound();
          }
            //return await _context.Serviceproviderbadges.ToListAsync();
            var serviceproviderbadges = await _context.Serviceproviderbadges.ToListAsync();
            List<ServiceproviderbadgeDTO> lstserviceproviderbadgeDTO = new List<ServiceproviderbadgeDTO>();
            lstserviceproviderbadgeDTO = _mapper.Map<List<ServiceproviderbadgeDTO>>(serviceproviderbadges);
            return lstserviceproviderbadgeDTO;
        }

        // GET: api/Serviceproviderbadges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceproviderbadgeDTO>> GetServiceproviderbadge(int id)
        {
          if (_context.Serviceproviderbadges == null)
          {
              return NotFound();
          }
            var serviceproviderbadge = await _context.Serviceproviderbadges.FindAsync(id);
            ServiceproviderbadgeDTO serviceproviderbadgeDTO = _mapper.Map<ServiceproviderbadgeDTO>(serviceproviderbadge);
            if (serviceproviderbadge == null)
            {
                return NotFound();
            }

            return serviceproviderbadgeDTO;
        }

        // PUT: api/Serviceproviderbadges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceproviderbadge(int id, [FromBody] ServiceproviderbadgeDTO serviceproviderbadgeDTO)
        {
            if (id != serviceproviderbadgeDTO.Id)
            {
                return BadRequest();
            }
            Serviceproviderbadge serviceproviderbadge = _mapper.Map<Serviceproviderbadge>(serviceproviderbadgeDTO);
            if (serviceproviderbadge != null)
                _context.Entry(serviceproviderbadgeDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceproviderbadgeExists(id))
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

        // POST: api/Serviceproviderbadges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceproviderbadgeDTO>> PostServiceproviderbadge([FromBody] ServiceproviderbadgeDTO serviceproviderbadgeDTO)
        {
          if (_context.Serviceproviderbadges == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Serviceproviderbadges'  is null.");
          }
            Serviceproviderbadge serviceproviderbadge = _mapper.Map<Serviceproviderbadge>(serviceproviderbadgeDTO);
            _context.Serviceproviderbadges.Add(serviceproviderbadge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceproviderbadge", new { id = serviceproviderbadge.Id }, serviceproviderbadge);
        }

        // DELETE: api/Serviceproviderbadges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceproviderbadge(int id)
        {
            if (_context.Serviceproviderbadges == null)
            {
                return NotFound();
            }
            var serviceproviderbadge = await _context.Serviceproviderbadges.FindAsync(id);
            if (serviceproviderbadge == null)
            {
                return NotFound();
            }

            _context.Serviceproviderbadges.Remove(serviceproviderbadge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceproviderbadgeExists(int id)
        {
            return (_context.Serviceproviderbadges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
