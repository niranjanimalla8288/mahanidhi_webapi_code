using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public AddController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Amenities
        [Route("getByName")]
        [HttpGet]
        public IActionResult GetAddDetails(int Id)
        {
            var add = _context.Adds
                .Where(c => c.Id == Id)
                .Select(c => new { AddPlace = c.AddPlace})
                .FirstOrDefault();

            if (add == null)
            {
                return NotFound(); 
            }

            return Ok(add);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddDTO>>> GetAdd()
        {
            if (_context.Adds == null)
            {
                return NotFound();
            }
            //return await _context.Add.ToListAsync();
            var add = await _context.Adds.ToListAsync();
            List<AddDTO> lstAddDTO = new List<AddDTO>();
            lstAddDTO = _mapper.Map<List<AddDTO>>(add);
            return lstAddDTO;
        }
        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdd(int id, AddDTO addDTO)
        {
            if (id != addDTO.Id)
            {
                return BadRequest();
            }
            Add add = _mapper.Map<Add>(addDTO);
            if (add != null)
                _context.Entry(add).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddExisting(id))
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

        private bool AddExists(int id)
        {
            throw new NotImplementedException();
        }
        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Add>> PostAdd(AddDTO addDTO)
        {
            if (_context.Adds == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.Adds'  is null.");
            }
            Add add = _mapper.Map<Add>(addDTO);
            _context.Adds.Add(add);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdd", new { id = add.Id }, add);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdd(int id)
        {
            if (_context.Adds == null)
            {
                return NotFound();
            }
            var add = await _context.Adds.FindAsync(id);
            if (add == null)
            {
                return NotFound();
            }

            _context.Adds.Remove(add);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddExisting(int id)
        {
            return (_context.Adds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
