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
    public class ServiceproviderservicesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceproviderservicesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

            // GET: api/Serviceproviderservices
            [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceproviderserviceDTO>>> GetServiceproviderservices()
        {
          if (_context.Serviceproviderservices == null)
          {
              return NotFound();
          }
            //return await _context.Serviceproviderservices.ToListAsync();
            var serviceproviderservices = await _context.Serviceproviderservices.ToListAsync();
            List<ServiceproviderserviceDTO> lstserviceproviderserviceDTO = new List<ServiceproviderserviceDTO>();
            lstserviceproviderserviceDTO = _mapper.Map<List<ServiceproviderserviceDTO>>(serviceproviderservices);
            return lstserviceproviderserviceDTO;
        }

        // GET: api/Serviceproviderservices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceproviderserviceDTO>> GetServiceproviderservice(int id)
        {
          if (_context.Serviceproviderservices == null)
          {
              return NotFound();
          }
            var serviceproviderservice = await _context.Serviceproviderservices.FindAsync(id);
            ServiceproviderserviceDTO serviceproviderserviceDTO = _mapper.Map<ServiceproviderserviceDTO>(serviceproviderservice);
            if (serviceproviderservice == null)
            {
                return NotFound();
            }

            return serviceproviderserviceDTO;
        }

        // PUT: api/Serviceproviderservices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceproviderservice(int id, [FromBody] ServiceproviderserviceDTO serviceproviderserviceDTO)
        {
            if (id != serviceproviderserviceDTO.Id)
            {
                return BadRequest();
            }
            Serviceproviderservice serviceproviderservice = _mapper.Map<Serviceproviderservice>(serviceproviderserviceDTO);
            if (serviceproviderservice != null)
                _context.Entry(serviceproviderservice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceproviderserviceExists(id))
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

        // POST: api/Serviceproviderservices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceproviderserviceDTO>> PostServiceproviderservice([FromBody] ServiceproviderserviceDTO serviceproviderserviceDTO)
        {
          if (_context.Serviceproviderservices == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Serviceproviderservices'  is null.");
          }
            Serviceproviderservice serviceproviderservice = _mapper.Map<Serviceproviderservice>(serviceproviderserviceDTO);
            _context.Serviceproviderservices.Add(serviceproviderservice);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceproviderservice", new { id = serviceproviderservice.Id }, serviceproviderservice);
        }

        // DELETE: api/Serviceproviderservices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceproviderservice(int id)
        {
            if (_context.Serviceproviderservices == null)
            {
                return NotFound();
            }
            var serviceproviderservice = await _context.Serviceproviderservices.FindAsync(id);
            if (serviceproviderservice == null)
            {
                return NotFound();
            }

            _context.Serviceproviderservices.Remove(serviceproviderservice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceproviderserviceExists(int id)
        {
            return (_context.Serviceproviderservices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
