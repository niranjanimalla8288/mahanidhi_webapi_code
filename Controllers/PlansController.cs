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
    public class PlansController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public PlansController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanDTO>>> GetPlans()
        {
          if (_context.Plans == null)
          {
              return NotFound();
          }
            // return await _context.Plans.ToListAsync();
            var plans = await _context.Plans.ToListAsync();
            List<PlanDTO> lstplanDTO = new List<PlanDTO>();
            lstplanDTO = _mapper.Map<List<PlanDTO>>(plans);
            return lstplanDTO;
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanDTO>> GetPlan(int id)
        {
          if (_context.Plans == null)
          {
              return NotFound();
          }
            var plan = await _context.Plans.FindAsync(id);
            PlanDTO planDTO = _mapper.Map<PlanDTO>(plan);
            if (plan == null)
            {
                return NotFound();
            }

            return planDTO;
        }

        // PUT: api/Plans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, PlanDTO  planDTO)
        {
            if (id != planDTO.Id)
            {
                return BadRequest();
            }
            Plan plan = _mapper.Map<Plan>(planDTO);
            if (plan != null)
                _context.Entry(plan).State = EntityState.Modified;
             
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
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

        // POST: api/Plans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(PlanDTO planDTO)
        {
          if (_context.Plans == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Plans'  is null.");
          }
            Plan plan = _mapper.Map<Plan>(planDTO);
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.Id }, plan);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            if (_context.Plans == null)
            {
                return NotFound();
            }
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanExists(int id)
        {
            return (_context.Plans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
