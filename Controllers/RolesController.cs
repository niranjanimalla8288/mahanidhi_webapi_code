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
    public class RolesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public RolesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
          if (_context.Roles == null)
          {
              return NotFound();
          }
           // return await _context.Roles.ToListAsync();
            var roles = await _context.Roles.ToListAsync();
            List<RoleDTO> lstroleDTO = new List<RoleDTO>();
            lstroleDTO = _mapper.Map<List<RoleDTO>>(roles);
            return lstroleDTO;
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
          if (_context.Roles == null)
          {
              return NotFound();
          }
            var role = await _context.Roles.FindAsync(id);
            RoleDTO roleDTO = _mapper.Map<RoleDTO>(role);
            if (role == null)
            {
                return NotFound();
            }

            return roleDTO;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleDTO roleDTO)
        {
            if (id != roleDTO.Id)
            {
                return BadRequest();
            }
            Role role = _mapper.Map<Role>(roleDTO);
            if (role != null)
                _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(RoleDTO roleDTO)
        {
          if (_context.Roles == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Roles'  is null.");
          }
            Role role = _mapper.Map<Role>(roleDTO);
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
