using MahaanidhiWebAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly MahaanidhieximContext _context;

        public ContactsController(MahaanidhieximContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContacts(int id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }
        [HttpPost]
        public async Task<ActionResult<Contact>> PostCountry([FromBody] Contact contact)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'MahanadhieximContext.Contacts'  is null.");
            }
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            Helper.MailSender.sendContactEnquiry(contact.Name, contact.Phone, contact.Email);

            return CreatedAtAction("GetContacts", new { id = contact.Id }, contact);
        }
    }
}
