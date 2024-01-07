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
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomfieldsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public CustomfieldsController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Customfields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomfieldDTO>>> GetCustomfields()
        {
          if (_context.Customfields == null)
          {
              return NotFound();
          }
            //return await _context.Customfields.ToListAsync();
            var customfields = await _context.Customfields.ToListAsync();
            List<CustomfieldDTO> lstcustomfieldDTO = new List<CustomfieldDTO>();
            lstcustomfieldDTO = _mapper.Map<List<CustomfieldDTO>>(customfields);
            return lstcustomfieldDTO;
        }

        // GET: api/Customfields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomfieldDTO>> GetCustomfield(int id)
        {
          if (_context.Customfields == null)
          {
              return NotFound();
          }
            var customfield = await _context.Customfields.FindAsync(id);
            CustomfieldDTO customfieldDTO = _mapper.Map<CustomfieldDTO>(customfield);
            if (customfield == null)
            {
                return NotFound();
            }

            return customfieldDTO;
        }

        // PUT: api/Customfields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomfield(int id, CustomfieldDTO customfieldDTO)
        {
            if (id != customfieldDTO.Id)
            {
                return BadRequest();
            }

            Customfield customfield = _mapper.Map<Customfield>(customfieldDTO);
            if (customfield != null)

                _context.Entry(customfield).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomfieldExists(id))
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

        // POST: api/Customfields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Customfield>> PostCustomfield(CustomfieldDTO customfieldDTO)
        {
          if (_context.Customfields == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Customfields'  is null.");
          }
            Customfield customfield = _mapper.Map<Customfield>(customfieldDTO);
            _context.Customfields.Add(customfield);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomfield", new { id = customfield.Id }, customfield);
        }

        // DELETE: api/Customfields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomfield(int id)
        {
            if (_context.Customfields == null)
            {
                return NotFound();
            }
            var customfield = await _context.Customfields.FindAsync(id);
            if (customfield == null)
            {
                return NotFound();
            }

            _context.Customfields.Remove(customfield);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomfieldExists(int id)
        {
            return (_context.Customfields?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
