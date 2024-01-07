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
    public class PaymentmodesController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public PaymentmodesController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Paymentmodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentmodeDTO>>> GetPaymentmodes()
        {
          if (_context.Paymentmodes == null)
          {
              return NotFound();
          }

            var paymentmodes = await _context.Paymentmodes.ToListAsync();
            List<PaymentmodeDTO> lstpaymentmodeDTO = new List<PaymentmodeDTO>();
            lstpaymentmodeDTO = _mapper.Map<List<PaymentmodeDTO>>(paymentmodes);
            return lstpaymentmodeDTO;
        }

        // GET: api/Paymentmodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentmodeDTO>> GetPaymentmode(int id)
        {
          if (_context.Paymentmodes == null)
          {
              return NotFound();
          }
            var paymentmode = await _context.Paymentmodes.FindAsync(id);
            PaymentmodeDTO paymentmodeDTO = _mapper.Map<PaymentmodeDTO>(paymentmode);
            
            if (paymentmode == null)
            {
                return NotFound();
            }

            return paymentmodeDTO;
        }

        // PUT: api/Paymentmodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentmode(int id, PaymentmodeDTO paymentmodeDTO)
        {
            if (id != paymentmodeDTO.Id)
            {
                return BadRequest();
            }
            Paymentmode paymentmode= _mapper.Map<Paymentmode>(paymentmodeDTO);
            if (paymentmode != null)
                _context.Entry(paymentmode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentmodeExists(id))
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

        // POST: api/Paymentmodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PaymentmodeDTO>> PostPaymentmode(PaymentmodeDTO paymentmodeDTO)
        {
          if (_context.Paymentmodes == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Paymentmodes'  is null.");
          }
            Paymentmode paymentmode = _mapper.Map<Paymentmode>(paymentmodeDTO);
            _context.Paymentmodes.Add(paymentmode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentmode", new { id = paymentmode.Id }, paymentmode);
        }

        // DELETE: api/Paymentmodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentmode(int id)
        {
            if (_context.Paymentmodes == null)
            {
                return NotFound();
            }
            var paymentmode = await _context.Paymentmodes.FindAsync(id);
            if (paymentmode == null)
            {
                return NotFound();
            }

            _context.Paymentmodes.Remove(paymentmode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentmodeExists(int id)
        {
            return (_context.Paymentmodes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
