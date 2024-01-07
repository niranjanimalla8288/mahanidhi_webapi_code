using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessRegistrationsController : ControllerBase
    {
        public MahaanidhieximContext _context=new MahaanidhieximContext();


        [HttpGet]
        public IEnumerable<BusinessRegistration> get() { 
        
            return _context.BusinessRegistrations.ToList();
        }

        [HttpPost]

        public BusinessRegistration post(BusinessRegistrationDTO businessRegistrationDTO)
        {
            BusinessRegistration businessRegistration=new BusinessRegistration();

            businessRegistration.FirstName=businessRegistrationDTO.FirstName;
            businessRegistration.LastName = businessRegistrationDTO.LastName;
            businessRegistration.Email=businessRegistrationDTO.Email;
            businessRegistration.CompanyName = businessRegistrationDTO.CompanyName;
            businessRegistration.Address = businessRegistrationDTO.Address;
            businessRegistration.PhoneNumber= businessRegistrationDTO.PhoneNumber;

            _context.Add(businessRegistration);
            _context.SaveChanges();
            return businessRegistration;

        }
    }
}
