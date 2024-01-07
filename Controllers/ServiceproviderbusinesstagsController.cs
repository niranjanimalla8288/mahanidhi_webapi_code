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
    public class ServiceproviderbusinesstagsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceproviderbusinesstagsController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceproviderbusinesstags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceproviderbusinesstagDTO>>> GetServiceproviderbusinesstags()
        {
          if (_context.Serviceproviderbusinesstags == null)
          {
              return NotFound();
          }
            //  return await _context.Serviceproviderbusinesstags.ToListAsync();
            var serviceproviderbusinesstags = await _context.Serviceproviderbusinesstags.ToListAsync();
            List<ServiceproviderbusinesstagDTO> lstserviceproviderbusinesstagDTO = new List<ServiceproviderbusinesstagDTO>();
            lstserviceproviderbusinesstagDTO = _mapper.Map<List<ServiceproviderbusinesstagDTO>>(serviceproviderbusinesstags);
            return lstserviceproviderbusinesstagDTO;
        }

        // GET: api/Serviceproviderbusinesstags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceproviderbusinesstagDTO>> GetServiceproviderbusinesstag(int id)
        {
          if (_context.Serviceproviderbusinesstags == null)
          {
              return NotFound();
          }
            var serviceproviderbusinesstag = await _context.Serviceproviderbusinesstags.FindAsync(id);
            ServiceproviderbusinesstagDTO serviceproviderbusinesstagDTO = _mapper.Map<ServiceproviderbusinesstagDTO>(serviceproviderbusinesstag);
            if (serviceproviderbusinesstag == null)
            {
                return NotFound();
            }

            return serviceproviderbusinesstagDTO;
        }

        // PUT: api/Serviceproviderbusinesstags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceproviderbusinesstag(int id, ServiceproviderbusinesstagDTO serviceproviderbusinesstagDTO)
        {
            if (id != serviceproviderbusinesstagDTO.Id)
            {
                return BadRequest();
            }
            Serviceproviderbusinesstag serviceproviderbusinesstag = _mapper.Map<Serviceproviderbusinesstag>(serviceproviderbusinesstagDTO);
            _context.Entry(serviceproviderbusinesstag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceproviderbusinesstagExists(id))
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

        // POST: api/Serviceproviderbusinesstags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceproviderbusinesstagDTO>> PostServiceproviderbusinesstag(ServiceproviderbusinesstagDTO serviceproviderbusinesstagDTO)
        {
          if (_context.Serviceproviderbusinesstags == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Serviceproviderbusinesstags'  is null.");
          }
            Serviceproviderbusinesstag serviceproviderbusinesstag = _mapper.Map<Serviceproviderbusinesstag>(serviceproviderbusinesstagDTO);
            _context.Serviceproviderbusinesstags.Add(serviceproviderbusinesstag);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceproviderbusinesstag", new { id = serviceproviderbusinesstag.Id }, serviceproviderbusinesstag);
        }

        // DELETE: api/Serviceproviderbusinesstags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceproviderbusinesstag(int id)
        {
            if (_context.Serviceproviderbusinesstags == null)
            {
                return NotFound();
            }
            var serviceproviderbusinesstag = await _context.Serviceproviderbusinesstags.FindAsync(id);
            if (serviceproviderbusinesstag == null)
            {
                return NotFound();
            }

            _context.Serviceproviderbusinesstags.Remove(serviceproviderbusinesstag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceproviderbusinesstagExists(int id)
        {
            return (_context.Serviceproviderbusinesstags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
