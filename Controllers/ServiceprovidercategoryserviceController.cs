using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MahaanidhiWebAPI.Mappers.GlobalMapper;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceprovidercategoryserviceController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;

        public ServiceprovidercategoryserviceController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceprovidercategoryservice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceprovidercategoryserviceDTO>>> GetServiceprovidercategoryservice()
        {
            if (_context.Serviceprovidercategoryservices == null)
            {
                return NotFound();
            }
            var serviceproviderCategoryService = await _context.Serviceprovidercategoryservices.ToListAsync();
            List<ServiceprovidercategoryserviceDTO> lstServiceprovidercategoryserviceDTO = new List<ServiceprovidercategoryserviceDTO>();
            lstServiceprovidercategoryserviceDTO = _mapper.Map<List<ServiceprovidercategoryserviceDTO>>(serviceproviderCategoryService);
            return lstServiceprovidercategoryserviceDTO;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceprovidercategoryserviceDTO>> GetBadge(int id)
        {
            if (_context.Serviceprovidercategoryservices == null)
            {
                return NotFound();
            }
            var serviceproviderCategoryService = await _context.Serviceprovidercategoryservices.FindAsync(id);
            ServiceprovidercategoryserviceDTO serviceprovidercategoryserviceDTO = _mapper.Map<ServiceprovidercategoryserviceDTO>(serviceproviderCategoryService);

            //MyOwnClass myOwnClass = _mapper.Map<MyOwnClass>(badge);

            if (serviceproviderCategoryService == null)
            {
                return NotFound();
            }

            return serviceprovidercategoryserviceDTO;
        }


        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBadge(int id, ServiceprovidercategoryserviceDTO serviceprovidercategoryserviceDTO)
        {
            if (id != serviceprovidercategoryserviceDTO.Id)
            {
                return BadRequest();
            }

            Serviceprovidercategoryservice serviceprovidercategoryservice= _mapper.Map<Serviceprovidercategoryservice>(serviceprovidercategoryserviceDTO);
            if (serviceprovidercategoryservice!= null)
                _context.Entry(serviceprovidercategoryservice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceprovidercategoryservicesExists(id))
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
        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceprovidercategoryDTO>> PostBadge(ServiceprovidercategoryDTO serviceprovidercategoryDTO)
        {
            if (serviceprovidercategoryDTO == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.Badges'  is null.");
            }
            Serviceprovidercategoryservice serviceprovidercategoryservice= _mapper.Map<Serviceprovidercategoryservice>(serviceprovidercategoryDTO);
            _context.Serviceprovidercategoryservices.Add(serviceprovidercategoryservice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBadge", new { id = serviceprovidercategoryservice.Id }, serviceprovidercategoryservice);
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBadge(int id)
        {
            if (_context.Serviceprovidercategoryservices == null)
            {
                return NotFound();
            }
            var serviceProviderCategoryService= await _context.Serviceprovidercategoryservices.FindAsync(id);
            if (serviceProviderCategoryService == null)
            {
                return NotFound();
            }

            _context.Serviceprovidercategoryservices.Remove(serviceProviderCategoryService);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool ServiceprovidercategoryservicesExists(int id)
        {
            return (_context.Serviceprovidercategoryservices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
