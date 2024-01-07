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
    public class StatesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public StatesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetStates()
        {
          if (_context.States == null)
          {
              return NotFound();
          }
            //return await _context.States.ToListAsync();
            var states = await _context.States.ToListAsync();
            List<StateDTO> lststateDTO = new List<StateDTO>();
            lststateDTO = _mapper.Map<List<StateDTO>>(states);
            return lststateDTO;
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateDTO>> GetState(int id)
        {
          if (_context.States == null)
          {
              return NotFound();
          }
            var state = await _context.States.FindAsync(id);
            StateDTO stateDTO = _mapper.Map<StateDTO>(state);
            if (state == null)
            {
                return NotFound();
            }

            return stateDTO;
        }

        // GET: api/Cities
        [Route("getstatecities")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities(int id)
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var cities = await _context.Cities.Where(c => c.StateId == id).ToListAsync();
            var count=cities.Count;

            List<CityDTO> lstcityDTO = new List<CityDTO>();
            lstcityDTO = _mapper.Map<List<CityDTO>>(cities);
            return lstcityDTO;
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, [FromBody] StateDTO stateDTO)
        {
            if (id != stateDTO.Id)
            {
                return BadRequest();
            }
            State state = _mapper.Map<State>(stateDTO);
            if (state != null)

                _context.Entry(state).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<State>> PostState([FromBody] StateDTO stateDTO)
        {
          if (_context.States == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.States'  is null.");
          }
            State state = _mapper.Map<State>(stateDTO);
            _context.States.Add(state);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetState", new { id = state.Id }, state);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            if (_context.States == null)
            {
                return NotFound();
            }
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.States.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(int id)
        {
            return (_context.States?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
