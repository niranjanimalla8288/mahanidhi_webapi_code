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
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public CountriesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountries()
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            // return await _context.Countries.ToListAsync();
            var countries = await _context.Countries.ToListAsync();
            List<CountryDTO> lstcountryDTO = new List<CountryDTO>();
            lstcountryDTO=_mapper.Map<List<CountryDTO>>(countries);
            return lstcountryDTO;
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            var country = await _context.Countries.FindAsync(id);
            CountryDTO countryDTO = _mapper.Map<CountryDTO>(country);
            if (country == null)
            {
                return NotFound();
            }

            return countryDTO;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id,[FromBody] CountryDTO countryDTO)
        {
            if (id != countryDTO.Id)
            {
                return BadRequest();
            }
            
            Country country=_mapper.Map<Country>(countryDTO);
            if (country != null)
                _context.Entry(countryDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry([FromBody] CountryDTO countryDTO)
        {
          if (_context.Countries == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Countries'  is null.");
          }
            Country country = _mapper.Map<Country>(countryDTO);
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
