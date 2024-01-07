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
    public class ServiceprovidercategoriesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceprovidercategoriesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceprovidercategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceprovidercategoryDTO>>> GetServiceprovidercategories()
        {
          if (_context.Serviceprovidercategories == null)
          {
              return NotFound();
          }
            // return await _context.Serviceprovidercategories.ToListAsync();
            var serviceprovidercategories = await _context.Serviceprovidercategories.ToListAsync();
            List<ServiceprovidercategoryDTO> lstserviceprovidercategoryDTO = new List<ServiceprovidercategoryDTO>();
            lstserviceprovidercategoryDTO = _mapper.Map<List<ServiceprovidercategoryDTO>>(serviceprovidercategories);
            return lstserviceprovidercategoryDTO;
        }

        // GET: api/Serviceprovidercategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceprovidercategoryDTO>> GetServiceprovidercategory(int id)
        {
          if (_context.Serviceprovidercategories == null)
          {
              return NotFound();
          }
            var serviceprovidercategory = await _context.Serviceprovidercategories.FindAsync(id);
            ServiceprovidercategoryDTO serviceprovidercategoryDTO = _mapper.Map<ServiceprovidercategoryDTO>(serviceprovidercategory);
            if (serviceprovidercategory == null)
            {
                return NotFound();
            }

            return serviceprovidercategoryDTO;
        }
        [Route("getCategoryData")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceproviderDTO>>> GetCities(int id)
        {
            if (_context.Serviceproviders == null)
            {
                return NotFound();
            }
            var category = await _context.Serviceproviders.Where(c => c.MainCategoryId == id).ToListAsync();
           var categoryCount=  _context.Serviceproviders.Count(c=> c.MainCategoryId == id).ToString();

            List<ServiceproviderDTO> lstServiceproviderDTO = new List<ServiceproviderDTO>();
            lstServiceproviderDTO = _mapper.Map<List<ServiceproviderDTO>>(category);
            return lstServiceproviderDTO;
        }

       

        // PUT: api/Serviceprovidercategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceprovidercategory(int id, ServiceprovidercategoryDTO serviceprovidercategoryDTO)
        {
            if (id != serviceprovidercategoryDTO.Id)
            {
                return BadRequest();
            }
            Serviceprovidercategory serviceprovidercategory = _mapper.Map<Serviceprovidercategory>(serviceprovidercategoryDTO);
            if (serviceprovidercategory != null)
                _context.Entry(serviceprovidercategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceprovidercategoryExists(id))
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

        // POST: api/Serviceprovidercategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceprovidercategoryDTO>> PostServiceprovidercategory(ServiceprovidercategoryDTO serviceprovidercategoryDTO)
        {
          if (_context.Serviceprovidercategories == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Serviceprovidercategories'  is null.");
          }
            Serviceprovidercategory serviceprovidercategory = _mapper.Map<Serviceprovidercategory>(serviceprovidercategoryDTO);
            _context.Serviceprovidercategories.Add(serviceprovidercategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceprovidercategory", new { id = serviceprovidercategory.Id }, serviceprovidercategory);
        }

        // DELETE: api/Serviceprovidercategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceprovidercategory(int id)
        {
            if (_context.Serviceprovidercategories == null)
            {
                return NotFound();
            }
            var serviceprovidercategory = await _context.Serviceprovidercategories.FindAsync(id);
            if (serviceprovidercategory == null)
            {
                return NotFound();
            }

            _context.Serviceprovidercategories.Remove(serviceprovidercategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceprovidercategoryExists(int id)
        {
            return (_context.Serviceprovidercategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
