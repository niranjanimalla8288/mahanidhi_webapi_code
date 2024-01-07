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
    public class CityareasController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public CityareasController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cityareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityareaDTO>>> GetCityareas()
        {
          if (_context.Cityareas == null)
          {
              return NotFound();
          }
            //return await _context.Cityareas.ToListAsync();
            var cityAreas = await _context.Cityareas.ToListAsync();
            List<CityareaDTO> lstcityAreaDTO = new List<CityareaDTO>();
            lstcityAreaDTO = _mapper.Map<List<CityareaDTO>>(cityAreas);
            return lstcityAreaDTO;
        }

        // GET: api/Cityareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityareaDTO>> GetCityarea(int id)
        {
          if (_context.Cityareas == null)
          {
              return NotFound();
          }
            var cityArea = await _context.Cityareas.FindAsync(id);
            CityareaDTO CityAreaDTO = _mapper.Map<CityareaDTO>(cityArea);
            if (cityArea == null)
            {
                return NotFound();
            }

            return CityAreaDTO;
        }

        // PUT: api/Cityareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityarea(int id, CityareaDTO cityAreaDTO)
        {
            if (id != cityAreaDTO.Id)
            {
                return BadRequest();
            }
            Cityarea cityArea = _mapper.Map<Cityarea>(cityAreaDTO);
            _context.Entry(cityArea).State = EntityState.Modified;

            try
            {   
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityareaExists(id))
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

        // POST: api/Cityareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cityarea>> PostCityarea(CityareaDTO cityAreaDTO)
        {
          if (_context.Cityareas == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Cityareas'  is null.");
          }
            Cityarea cityArea = _mapper.Map<Cityarea>(cityAreaDTO);
            _context.Cityareas.Add(cityArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityarea", new { id = cityArea.Id }, cityArea);
        }

        // DELETE: api/Cityareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityarea(int id)
        {
            if (_context.Cityareas == null)
            {
                return NotFound();
            }
            var cityarea = await _context.Cityareas.FindAsync(id);
            if (cityarea == null)
            {
                return NotFound();
            }

            _context.Cityareas.Remove(cityarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityareaExists(int id)
        {
            return (_context.Cityareas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
