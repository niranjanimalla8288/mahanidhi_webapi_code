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
    public class ServiceprovidersubcategoriesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceprovidersubcategoriesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceprovidersubcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceprovidersubcategoryDTO>>> GetServiceprovidersubcategories()
        {
          if (_context.Serviceprovidersubcategories == null)
          {
              return NotFound();
          }
            //  return await _context.Serviceprovidersubcategories.ToListAsync();
            var serviceprovidersubcategories = await _context.Serviceprovidersubcategories.ToListAsync();
            List<ServiceprovidersubcategoryDTO> lstserviceprovidersubcategoryDTO = new List<ServiceprovidersubcategoryDTO>();
            lstserviceprovidersubcategoryDTO = _mapper.Map<List<ServiceprovidersubcategoryDTO>>(serviceprovidersubcategories);
            return lstserviceprovidersubcategoryDTO;
        }

        // GET: api/Serviceprovidersubcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceprovidersubcategoryDTO>> GetServiceprovidersubcategory(int id)
        {
          if (_context.Serviceprovidersubcategories == null)
          {
              return NotFound();
          }
            var serviceprovidersubcategory = await _context.Serviceprovidersubcategories.FindAsync(id);
            ServiceprovidersubcategoryDTO serviceprovidersubcategoryDTO = _mapper.Map<ServiceprovidersubcategoryDTO>(serviceprovidersubcategory);
            if (serviceprovidersubcategory == null)
            {
                return NotFound();
            }

            return serviceprovidersubcategoryDTO;
        }

        // PUT: api/Serviceprovidersubcategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceprovidersubcategory(int id, ServiceprovidersubcategoryDTO serviceprovidersubcategoryDTO)
        {
            if (id != serviceprovidersubcategoryDTO.Id)
            {
                return BadRequest();
            }
            Serviceprovidersubcategory serviceprovidersubcategory = _mapper.Map<Serviceprovidersubcategory>(serviceprovidersubcategoryDTO);
            if (serviceprovidersubcategory != null)
                _context.Entry(serviceprovidersubcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceprovidersubcategoryExists(id))
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

        // POST: api/Serviceprovidersubcategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Serviceprovidersubcategory>> PostServiceprovidersubcategory(ServiceprovidersubcategoryDTO serviceprovidersubcategoryDTO)
        {
          if (_context.Serviceprovidersubcategories == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Serviceprovidersubcategories'  is null.");
          }
            Serviceprovidersubcategory serviceprovidersubcategory = _mapper.Map<Serviceprovidersubcategory>(serviceprovidersubcategoryDTO);
            _context.Serviceprovidersubcategories.Add(serviceprovidersubcategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceprovidersubcategory", new { id = serviceprovidersubcategory.Id }, serviceprovidersubcategory);
        }

        // DELETE: api/Serviceprovidersubcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceprovidersubcategory(int id)
        {
            if (_context.Serviceprovidersubcategories == null)
            {
                return NotFound();
            }
            var serviceprovidersubcategory = await _context.Serviceprovidersubcategories.FindAsync(id);
            if (serviceprovidersubcategory == null)
            {
                return NotFound();
            }

            _context.Serviceprovidersubcategories.Remove(serviceprovidersubcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceprovidersubcategoryExists(int id)
        {
            return (_context.Serviceprovidersubcategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
