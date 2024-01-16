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
    public class BusinessRegistrationsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;

        public BusinessRegistrationsController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BusinessRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessRegistrationDTO>>> GetBusinessRegistrations()
        {
            if (_context.BusinessRegistrations == null)
            {
                return NotFound();
            }
            var BusinessRegistrations = await _context.BusinessRegistrations.ToListAsync();
            List<BusinessRegistrationDTO> lstBusinessRegistrationDTO = new List<BusinessRegistrationDTO>();
            lstBusinessRegistrationDTO = _mapper.Map<List<BusinessRegistrationDTO>>(BusinessRegistrations);
            return lstBusinessRegistrationDTO;
        }

        // GET: api/BusinessRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessRegistrationDTO>> GetbusinessRegistration(int id)
        {
            if (_context.BusinessRegistrations == null)
            {
                return NotFound();
            }
            var businessRegistration = await _context.BusinessRegistrations.FindAsync(id);
            BusinessRegistrationDTO BusinessRegistrationDTO = _mapper.Map<BusinessRegistrationDTO>(businessRegistration);

            //MyOwnClass myOwnClass = _mapper.Map<MyOwnClass>(businessRegistration);

            if (businessRegistration == null)
            {
                return NotFound();
            }

            return BusinessRegistrationDTO;
        }

        // PUT: api/BusinessRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}")]
        public async Task<IActionResult> PutbusinessRegistration(int id, BusinessRegistrationDTO BusinessRegistrationDTO)
        {
            if (id != BusinessRegistrationDTO.Id)
            {
                return BadRequest();
            }

            BusinessRegistration businessRegistration = _mapper.Map<BusinessRegistration>(BusinessRegistrationDTO);
            if (businessRegistration != null)
                _context.Entry(businessRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!businessRegistrationExists(id))
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

        // POST: api/BusinessRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<BusinessRegistrationDTO>> PostbusinessRegistration(BusinessRegistrationDTO BusinessRegistrationDTO)
        {
            if (BusinessRegistrationDTO == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.BusinessRegistrations'  is null.");
            }
            BusinessRegistration businessRegistration = _mapper.Map<BusinessRegistration>(BusinessRegistrationDTO);
            _context.BusinessRegistrations.Add(businessRegistration);
            await _context.SaveChangesAsync();
            try{
                  //Send mail
            Helper.MailSender.SendRegistrationEnquiryMail(BusinessRegistrationDTO.Email,BusinessRegistrationDTO.PhoneNumber,BusinessRegistrationDTO.CompanyName);  
            }
            catch{

            }
            

            return CreatedAtAction("GetbusinessRegistration", new { id = businessRegistration.Id }, businessRegistration);
        }

        // DELETE: api/BusinessRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletebusinessRegistration(int id)
        {
            if (_context.BusinessRegistrations == null)
            {
                return NotFound();
            }
            var businessRegistration = await _context.BusinessRegistrations.FindAsync(id);
            if (businessRegistration == null)
            {
                return NotFound();
            }

            _context.BusinessRegistrations.Remove(businessRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool businessRegistrationExists(int id)
        {
            return (_context.BusinessRegistrations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
