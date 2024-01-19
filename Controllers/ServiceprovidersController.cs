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
    public class ServiceprovidersController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;
        private readonly IMapper _mapper;
        public ServiceprovidersController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Serviceproviders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceproviderDTO>>> GetServiceproviders()
        {
          if (_context.Serviceproviders == null)
          {
              return NotFound();
          }
            //return await _context.Serviceproviders.ToListAsync();
            var serviceprovider = await _context.Serviceproviders.ToListAsync();
            List<ServiceproviderDTO> lstserviceproviderDTO = new List<ServiceproviderDTO>();
            lstserviceproviderDTO = _mapper.Map<List<ServiceproviderDTO>>(serviceprovider);

         
            return lstserviceproviderDTO;
        }
        // GET: api/ServiceProvider
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceproviderDTO>> GetServiceProvider(int id)
        {
            if (_context.Serviceproviders == null)
            {
                return NotFound();
            }
            var serviceProvider = await _context.Serviceproviders.FindAsync(id);
            ServiceproviderDTO serviceproviderDTO= _mapper.Map<ServiceproviderDTO>(serviceProvider);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return serviceproviderDTO;
        }

        [HttpGet("CountMainCategories")]
        public async Task<IActionResult> CountMainCategories()
        {
            try
            {
                // Assuming ServiceproviderDTO is the DbSet for ServiceproviderDTO entities
                var mainCategoryIdCounts = await _context.Serviceproviders
                    .Where(provider => provider.MainCategoryId != null)
                    .GroupBy(provider => provider.MainCategoryId)
                    .Select(group => new
                    {
                        MainCategoryId = group.Key,
                        Count = group.Count()
                    })
                    .ToListAsync();

                return Ok(mainCategoryIdCounts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("CountMainCategoriesWithDetails")]
        public async Task<IActionResult> CountMainCategoriesWithDetails()
        {
            try
            {
                var mainCategoriesWithDetails = await _context.Serviceproviders
                    .Where(provider => provider.MainCategoryId != null)
                    .GroupBy(provider => provider.MainCategoryId)
                    .Select(group => new
                    {
                        MainCategoryId = group.Key,
                        Count = group.Count(),
                        Details = group.Select(provider => new ServiceproviderDTO
                        {
                            Id = provider.Id,
                            MainCategoryId = provider.MainCategoryId,
                            // Include other properties you need
                        }).ToList()
                    })
                    .ToListAsync();

                return Ok(mainCategoriesWithDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        // PUT: api/Serviceproviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceprovider(int id, ServiceproviderDTO serviceproviderDTO)
        {
            if (id != serviceproviderDTO.Id)
            {
                return BadRequest();
            }
            Serviceprovider  serviceprovider= _mapper.Map<Serviceprovider>(serviceproviderDTO);
            if (serviceprovider != null)
                _context.Entry(serviceprovider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceproviderExists(id))
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


        // POST: api/Serviceproviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceproviderDTO>> PostServiceprovider(ServiceproviderDTO serviceproviderDTO)
        {
          if (_context.Serviceproviders == null)
          {
              return Problem("Entity set 'MahaanidhieximContext.Serviceproviders'  is null.");
          }
            Serviceprovider serviceprovider = _mapper.Map<Serviceprovider>(serviceproviderDTO);
            _context.Serviceproviders.Add(serviceprovider);
            await _context.SaveChangesAsync();

            // Send Mail
            Helper.MailSender.SendRegistrationMail(serviceprovider.Email,serviceprovider.MobileNumber,serviceprovider.BusinessName);

            return CreatedAtAction("GetServiceprovider", new { id = serviceprovider.Id }, serviceprovider);
        }

        // DELETE: api/Serviceproviders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceprovider(int id)
        {
            if (_context.Serviceproviders == null)
            {
                return NotFound();
            }
            var serviceprovider = await _context.Serviceproviders.FindAsync(id);
            if (serviceprovider == null)
            {
                return NotFound();
            }

            _context.Serviceproviders.Remove(serviceprovider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceproviderExists(int id)
        {
            return (_context.Serviceproviders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
