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

        // GET: api/Amenities
        [Route("getByCategoryByAddDetaisl")]
        [HttpGet]
        public IActionResult GetCityCategorryAddDetails(int cityId, int categoryId)
        {
            DateTime today = DateTime.Now;

            //var add = _context.Adds
            //    .Where(c => c.CityId == cityId && c.CategoryId == categoryId && (c.FromDate >= today && c.ToDate <= today))                
            //    .FirstOrDefault();

            var add = _context.Adds.ToList();
            if (add == null)
            {
                return NotFound();
            }

            return Ok(add);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddDTO>>> GetAdds()
        {
            if (_context.Adds == null)
            {
                return NotFound();
            }
            // return await _context.Countries.ToListAsync();
            var adds = await _context.Adds.ToListAsync();
            List<AddDTO> lstaddDTO = new List<AddDTO>();
            lstaddDTO = _mapper.Map<List<AddDTO>>(adds);
            return lstaddDTO;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAdd(int id, AddDTO addDTO)
        //{
        //    if (id != addDTO.Id)
        //    {
        //        return BadRequest();
        //    }
        //    Add add = _mapper.Map<Add>(addDTO);
        //    if (add != null)
        //        _context.Entry(add).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AddExisting(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        private bool AddExists(int id)
        {
            throw new NotImplementedException();
        }


        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Add>> PostAdd([FromBody]AddDTO addDTO)
        {
            // Check if add exists
            DateTime today = DateTime.Now;
            var addExists = _context.Adds
                .Where(c => c.CityId == addDTO.CityId && c.CategoryId == addDTO.CategoryId && (c.FromDate >= today && c.ToDate <= today))
                .FirstOrDefault();

            if(addExists != null)
            {
                return Problem("Add already exists for  this period.");
            }
            if (_context.Adds == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.Adds'  is null.");
            }
            Add add = _mapper.Map<Add>(addDTO);
            _context.Adds.Add(add);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddDetails", new { id = add.Id }, add);
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
