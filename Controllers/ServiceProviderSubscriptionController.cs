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
    public class ServiceProviderSubscriptionController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceProviderSubscriptionController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceprovidersubscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceprovidersubscriptionDTO>>> GetServiceprovidersubscriptions()
        {
            if (_context.Serviceprovidersubscriptions == null)
            {
                return NotFound();
            }
            // return await _context.Serviceprovidersubscriptions.ToListAsync();
            var servieProviderSubscription = await _context.Serviceprovidersubscriptions.ToListAsync();
            List<ServiceprovidersubscriptionDTO> lstserviceprovidersubscriptionDTO = new List<ServiceprovidersubscriptionDTO>();
            lstserviceprovidersubscriptionDTO = _mapper.Map<List<ServiceprovidersubscriptionDTO>>(servieProviderSubscription);
            return lstserviceprovidersubscriptionDTO;
        }

        // GET: api/Serviceprovidersubscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceprovidersubscriptionDTO>> GetPlan(int id)
        {
            if (_context.Serviceprovidersubscriptions == null)
            {
                return NotFound();
            }
            var serviceProviderSubscriptions = await _context.Serviceprovidersubscriptions.FindAsync(id);
            ServiceprovidersubscriptionDTO servuceProviderSubscriptionDto = _mapper.Map<ServiceprovidersubscriptionDTO>(serviceProviderSubscriptions);
            if (serviceProviderSubscriptions == null)
            {
                return NotFound();
            }

            return servuceProviderSubscriptionDto;
        }

        // PUT: api/Serviceprovidersubscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, ServiceprovidersubscriptionDTO serviceprovidersubscriptionDTO)
        {
            if (id != serviceprovidersubscriptionDTO.Id)
            {
                return BadRequest();
            }
            Serviceprovidersubscription serviceprovidersubscription = _mapper.Map<Serviceprovidersubscription>(serviceprovidersubscriptionDTO);
            if (serviceprovidersubscription != null)
                _context.Entry(serviceprovidersubscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceprovidersubscriptionsExists(id))
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

        // POST: api/Serviceprovidersubscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Serviceprovidersubscription>> PostPlan(ServiceprovidersubscriptionDTO serviceprovidersubscriptionDTO)
        {
            if (_context.Serviceprovidersubscriptions == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.Plans'  is null.");
            }
            Serviceprovidersubscription serviceprovidersubscription = _mapper.Map<Serviceprovidersubscription>(serviceprovidersubscriptionDTO);
            _context.Serviceprovidersubscriptions.Add(serviceprovidersubscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = serviceprovidersubscription.Id }, serviceprovidersubscription);
        }

        // DELETE: api/Serviceprovidersubscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceprovidersubscription(int id)
        {
            if (_context.Serviceprovidersubscriptions == null)
            {
                return NotFound();
            }
            var serviceprovidersubscription = await _context.Serviceprovidersubscriptions.FindAsync(id);
            if (serviceprovidersubscription == null)
            {
                return NotFound();
            }

            _context.Serviceprovidersubscriptions.Remove(serviceprovidersubscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceprovidersubscriptionsExists(int id)
        {
            return (_context.Serviceprovidersubscriptions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
