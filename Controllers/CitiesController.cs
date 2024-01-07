using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public CitiesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        
        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var cities = await _context.Cities.ToListAsync();
            List<CityDTO> lstcityDTO = new List<CityDTO>();
            lstcityDTO = _mapper.Map<List<CityDTO>>(cities);
            return lstcityDTO;
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> GetCity(int id)
        {
          if (_context.Cities == null)
          {
              return NotFound();
          }
            var city = await _context.Cities.FindAsync(id);
            CityDTO cityDTO=_mapper.Map<CityDTO>(city);

            if (city == null)
            {
                return NotFound();
            }

            return cityDTO;
        }
        [Route("getByCitywithID")]
        [HttpGet]
        public City getbyId(int id) {

            return _context.Cities.Where(c => c.Id == id).FirstOrDefault();
        }
        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, CityDTO cityDTO)
        {
            if (id != cityDTO.Id)
            {
                return BadRequest();
            }
            City city=_mapper.Map<City>(cityDTO);
            if(city != null)

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]

        //public City post(CityDTO city)
        //{
        //     City city1=new City();

        //    city1.Name = city.Name;
        //    city1.Gpslocation = city.Gpslocation;
        //    city1.StateId = city.StateId;
        //     _context.Add(city1);
        //    _context.SaveChanges();
        //    return city1;
        //}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CityDTO>> PostCity(CityDTO cityDTO)
        {
            if (_context.Cities == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.Cities'  is null.");
            }
            City city = _mapper.Map<City>(cityDTO);
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }


        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(int id)
        {
            return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
