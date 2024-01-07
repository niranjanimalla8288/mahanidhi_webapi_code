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
    public class OrganizationsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public OrganizationsController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Organizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationDTO>>> GetOrganizations()
        {
          if (_context.Organizations == null)
          {
              return NotFound();
          }
            var organizations = await _context.Organizations.ToListAsync();
            List<OrganizationDTO> lstorganizationsDTO = new List<OrganizationDTO>();
            lstorganizationsDTO = _mapper.Map<List<OrganizationDTO>>(organizations);
            return lstorganizationsDTO;
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationDTO>> GetOrganization(int id)
        {
          if (_context.Organizations == null)
          {
              return NotFound();
          }
            var organization = await _context.Organizations.FindAsync(id);
            OrganizationDTO organizationDTO = _mapper.Map<OrganizationDTO>(organization);
            
            if (organization == null)
            {
                return NotFound();
            }

            return organizationDTO;
        }

        // PUT: api/Organizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, OrganizationDTO organizationDTO)
        {
            if (id != organizationDTO.Id)
            {
                return BadRequest();
            }

            Organization organization = _mapper.Map<Organization>(organizationDTO);
            if (organization != null)
                _context.Entry(organization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
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

        // POST: api/Organizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrganizationDTO>> PostOrganization(OrganizationDTO organizationDTO)
        {
          if (_context.Organizations == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Organizations'  is null.");
          }
            Organization organization = _mapper.Map<Organization>(organizationDTO);
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
        }

        // DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            if (_context.Organizations == null)
            {
                return NotFound();
            }
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationExists(int id)
        {
            return (_context.Organizations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
