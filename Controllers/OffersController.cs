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
    public class OffersController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public OffersController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferDTO>>> GetOffers()
        {
          if (_context.Offers == null)
          {
              return NotFound();
          }
            // return await _context.Offers.ToListAsync();
            var offers = await _context.Offers.ToListAsync();
            List<OfferDTO> lstOfferDTO = new List<OfferDTO>();
            lstOfferDTO = _mapper.Map<List<OfferDTO>>(offers);
            return lstOfferDTO;
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDTO>> GetOffer(int id)
        {
          if (_context.Offers == null)
          {
              return NotFound();
          }
            var offer = await _context.Offers.FindAsync(id);
            OfferDTO offerDTO = _mapper.Map<OfferDTO>(offer);
            if (offer == null)
            {
                return NotFound();
            }

            return offerDTO;
        }

        // PUT: api/Offers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(int id, OfferDTO offerDTO)
        {
            if (id != offerDTO.Id)
            {
                return BadRequest();
            }
            Offer offer = _mapper.Map<Offer>(offerDTO);
            if (offer != null)
                _context.Entry(offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
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

        // POST: api/Offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(OfferDTO offerDTO)
        {
          if (_context.Offers == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Offers'  is null.");
          }
            Offer offer = _mapper.Map<Offer>(offerDTO);
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffer", new { id = offer.Id }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            if (_context.Offers == null)
            {
                return NotFound();
            }
            var offer = await _context.Offers.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfferExists(int id)
        {
            return (_context.Offers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
