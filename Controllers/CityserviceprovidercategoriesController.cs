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
    public class CityserviceprovidercategoriesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public CityserviceprovidercategoriesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cityserviceprovidercategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityserviceprovidercategoryDTO>>> GetCityserviceprovidercategories()
        {
          if (_context.Cityserviceprovidercategories == null)
          {
              return NotFound();
          }
            //return await _context.Cityserviceprovidercategories.ToListAsync();
            var cityserviceprovidercategories = await _context.Cityserviceprovidercategories.ToListAsync();
            List<CityserviceprovidercategoryDTO> lstcityserviceprovidercategoryDTO = new List<CityserviceprovidercategoryDTO>();
            lstcityserviceprovidercategoryDTO = _mapper.Map<List<CityserviceprovidercategoryDTO>>(cityserviceprovidercategories);
            return lstcityserviceprovidercategoryDTO; 
        }

        // GET: api/Cityserviceprovidercategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityserviceprovidercategoryDTO>> GetCityserviceprovidercategory(int id)
        {
          if (_context.Cityserviceprovidercategories == null)
          {
              return NotFound();
          }
            var cityserviceprovidercategory = await _context.Cityserviceprovidercategories.FindAsync(id);
            CityserviceprovidercategoryDTO cityserviceprovidercategoryDTO = _mapper.Map<CityserviceprovidercategoryDTO>(cityserviceprovidercategory);
            if (cityserviceprovidercategory == null)
            {
                return NotFound();
            }

            return cityserviceprovidercategoryDTO;
        }

        // PUT: api/Cityserviceprovidercategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityserviceprovidercategory(int id, CityserviceprovidercategoryDTO cityserviceprovidercategoryDTO)
        {
            if (id != cityserviceprovidercategoryDTO.Id)
            {
                return BadRequest();
            }
            Cityserviceprovidercategory cityserviceprovidercategory = _mapper.Map<Cityserviceprovidercategory>(cityserviceprovidercategoryDTO);
            if (cityserviceprovidercategory != null)
                _context.Entry(cityserviceprovidercategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityserviceprovidercategoryExists(id))
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

        // POST: api/Cityserviceprovidercategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CityserviceprovidercategoryDTO>> PostCityserviceprovidercategory(CityserviceprovidercategoryDTO cityserviceprovidercategoryDTO)
        {
          if (_context.Cityserviceprovidercategories == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Cityserviceprovidercategories'  is null.");
          }
            Cityserviceprovidercategory cityserviceprovidercategory = _mapper.Map<Cityserviceprovidercategory>(cityserviceprovidercategoryDTO);
            _context.Cityserviceprovidercategories.Add(cityserviceprovidercategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityserviceprovidercategory", new { id = cityserviceprovidercategoryDTO.Id }, cityserviceprovidercategoryDTO);
        }

        // DELETE: api/Cityserviceprovidercategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityserviceprovidercategory(int id)
        {
            if (_context.Cityserviceprovidercategories == null)
            {
                return NotFound();
            }
            var cityserviceprovidercategory = await _context.Cityserviceprovidercategories.FindAsync(id);
            if (cityserviceprovidercategory == null)
            {
                return NotFound();
            }

            _context.Cityserviceprovidercategories.Remove(cityserviceprovidercategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityserviceprovidercategoryExists(int id)
        {
            return (_context.Cityserviceprovidercategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
