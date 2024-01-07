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
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceprovidersubscriptionspaymentsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;

        public ServiceprovidersubscriptionspaymentsController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Serviceprovidersubscriptionspayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceprovidersubscriptionspaymentDTO>>> GetServiceprovidersubscriptionspayments()
        {
          if (_context.Serviceprovidersubscriptionspayments == null)
          {
              return NotFound();
          }
            // return await _context.Serviceprovidersubscriptionspayments.ToListAsync();
            var serviceprovidersubscriptionspayments = await _context.Serviceprovidersubscriptionspayments.ToListAsync();
            List<ServiceprovidersubscriptionspaymentDTO> lstserviceprovidersubscriptionspaymentDTO = new List<ServiceprovidersubscriptionspaymentDTO>();
            lstserviceprovidersubscriptionspaymentDTO = _mapper.Map<List<ServiceprovidersubscriptionspaymentDTO>>(serviceprovidersubscriptionspayments);
            return lstserviceprovidersubscriptionspaymentDTO;
        }

        // GET: api/Serviceprovidersubscriptionspayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceprovidersubscriptionspaymentDTO>> GetServiceprovidersubscriptionspayment(int id)
        {
          if (_context.Serviceprovidersubscriptionspayments == null)
          {
              return NotFound();
          }
            var serviceprovidersubscriptionspayment = await _context.Serviceprovidersubscriptionspayments.FindAsync(id);
            ServiceprovidersubscriptionspaymentDTO serviceprovidersubscriptionspaymentDTO = _mapper.Map<ServiceprovidersubscriptionspaymentDTO>(serviceprovidersubscriptionspayment);
            if (serviceprovidersubscriptionspayment == null)
            {
                return NotFound();
            }

            return serviceprovidersubscriptionspaymentDTO;
        }

        // PUT: api/Serviceprovidersubscriptionspayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceprovidersubscriptionspayment(int id, ServiceprovidersubscriptionspaymentDTO serviceprovidersubscriptionspaymentDTO)
        {
            if (id != serviceprovidersubscriptionspaymentDTO.Id)
            {
                return BadRequest();
            }
            Serviceprovidersubscriptionspayment serviceprovidersubscriptionspayment = _mapper.Map<Serviceprovidersubscriptionspayment>(serviceprovidersubscriptionspaymentDTO);
            if (serviceprovidersubscriptionspayment != null)

                _context.Entry(serviceprovidersubscriptionspayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceprovidersubscriptionspaymentExists(id))
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

        // POST: api/Serviceprovidersubscriptionspayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        //public Serviceprovidersubscriptionspayment post(ServiceprovidersubscriptionspaymentDTO serviceprovidersubscriptionspayment) {
        //    Serviceprovidersubscriptionspayment serviceprovidersubscriptionspayment1= new Serviceprovidersubscriptionspayment();

        //    serviceprovidersubscriptionspayment1.ServiceProviderId= serviceprovidersubscriptionspayment.ServiceProviderId;
        //    serviceprovidersubscriptionspayment1.PaidAmount = serviceprovidersubscriptionspayment.PaidAmount;
        //    serviceprovidersubscriptionspayment1.ServiceProviderSubscriptionId= serviceprovidersubscriptionspayment.ServiceProviderSubscriptionId;
        //    serviceprovidersubscriptionspayment1.PaymentModeId = serviceprovidersubscriptionspayment.PaymentModeId;
        //    serviceprovidersubscriptionspayment1.TransactionReference = serviceprovidersubscriptionspayment.TransactionReference;
        //    //branch1.PatientTransfer = branch.PatientTransfer;

        //    _context.Add(serviceprovidersubscriptionspayment1);
        //    _context.SaveChanges();
        //    return serviceprovidersubscriptionspayment1;
        //}
        public async Task<ActionResult<Serviceprovidersubscriptionspayment>> PostServiceprovidersubscriptionspayment([FromBody] ServiceprovidersubscriptionspaymentDTO serviceprovidersubscriptionspaymentDTO)
        {
            if (_context.Serviceprovidersubscriptionspayments == null)
            {
                return Problem("Entity set 'MahaanidhieximContext.Serviceprovidersubscriptionspayments'  is null.");
            }
            Serviceprovidersubscriptionspayment serviceprovidersubscriptionspayment = _mapper.Map<Serviceprovidersubscriptionspayment>(serviceprovidersubscriptionspaymentDTO);
            _context.Serviceprovidersubscriptionspayments.Add(serviceprovidersubscriptionspayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceprovidersubscriptionspayment", new { id = serviceprovidersubscriptionspayment.Id }, serviceprovidersubscriptionspayment);
        }

        // DELETE: api/Serviceprovidersubscriptionspayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceprovidersubscriptionspayment(int id)
        {
            if (_context.Serviceprovidersubscriptionspayments == null)
            {
                return NotFound();
            }
            var serviceprovidersubscriptionspayment = await _context.Serviceprovidersubscriptionspayments.FindAsync(id);
            if (serviceprovidersubscriptionspayment == null)
            {
                return NotFound();
            }

            _context.Serviceprovidersubscriptionspayments.Remove(serviceprovidersubscriptionspayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceprovidersubscriptionspaymentExists(int id)
        {
            return (_context.Serviceprovidersubscriptionspayments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
