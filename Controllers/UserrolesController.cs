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

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserrolesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public UserrolesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Userroles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserroleDTO>>> GetUserroles()
        {
          if (_context.Userroles == null)
          {
              return NotFound();
          }
            // return await _context.Userroles.ToListAsync();
            var userroles = await _context.Userroles.ToListAsync();
            List<UserroleDTO> lstuserroleDTO = new List<UserroleDTO>();
            lstuserroleDTO = _mapper.Map<List<UserroleDTO>>(userroles);
            return lstuserroleDTO;
        }

        // GET: api/Userroles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserroleDTO>> GetUserrole(int id)
        {
          if (_context.Userroles == null)
          {
              return NotFound();
          }
            var userrole = await _context.Userroles.FindAsync(id);
            UserroleDTO userroleDTO = _mapper.Map<UserroleDTO>(userrole);
            if (userrole == null)
            {
                return NotFound();
            }

            return userroleDTO;
        }

        // PUT: api/Userroles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserrole(int id, UserroleDTO userroleDTO)
        {
            if (id != userroleDTO.Id)
            {
                return BadRequest();
            }
            Userrole userrole = _mapper.Map<Userrole>(userroleDTO);
            if (userrole != null)
                _context.Entry(userrole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserroleExists(id))
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

        // POST: api/Userroles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userrole>> PostUserrole(UserroleDTO userroleDTO)
        {
          if (_context.Userroles == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Userroles'  is null.");
          }
            Userrole userrole = _mapper.Map<Userrole>(userroleDTO);
            _context.Userroles.Add(userrole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserrole", new { id = userrole.Id }, userrole);
        }

        // DELETE: api/Userroles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserrole(int id)
        {
            if (_context.Userroles == null)
            {
                return NotFound();
            }
            var userrole = await _context.Userroles.FindAsync(id);
            if (userrole == null)
            {
                return NotFound();
            }

            _context.Userroles.Remove(userrole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserroleExists(int id)
        {
            return (_context.Userroles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
