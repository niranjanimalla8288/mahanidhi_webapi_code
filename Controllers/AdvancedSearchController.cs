using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancedSearchController : ControllerBase
    {

        private readonly MahaanidhieximContext _context;
      
        public AdvancedSearchController(MahaanidhieximContext context)
        {
            _context = context;
         
        }

        //public IQueryable<Serviceprovider> SearchServiceProviders(int stateId, int cityId, int categoryId, string searchString)
        //{
        //    var query = _context.Serviceproviders.AsQueryable();

        //    // Check if StateId is provided and not equal to 0
        //    if (stateId != 0)
        //    {
        //        query = query.Where(provider => provider.StateId == stateId);
        //    }

        //    // Check if CityId is provided and not equal to 0
        //    if (cityId != 0)
        //    {
        //        query = query.Where(provider => provider.CityId == cityId);
        //    }

        //    // Check if CategoryId is provided and not equal to 0
        //    if (categoryId != 0)
        //    {
        //        query = query.Where(provider => provider.MainCategoryId == categoryId);
        //    }

        //    // Check if SearchString is provided
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        searchString = searchString.ToLower();
        //        query = query.Where(provider => provider.BusinessName.ToLower().Contains(searchString));
        //    }

        //    return query;
        //}


        [HttpGet]
        public IEnumerable<Serviceprovider> Get([FromQuery] AdvancedSearchDTO searchDTO)
        {


            // custmer SaveChangesEventArgs 
            if(searchDTO.CustomerName != string.Empty && (searchDTO.CustomerEmail != string.Empty || searchDTO.CustomerMobile != string.Empty))
            {
                // Create Customers
                Customer customer = new Customer();
                customer.Name = searchDTO.CustomerName; ;
                customer.Email = searchDTO.CustomerEmail;   
                customer.MobileNumber = searchDTO.CustomerMobile;
                customer.Address = searchDTO.LookingFor;

                _context.Customers.Add(customer);
                _context.SaveChanges();
            }

            // Assuming your DbContext has a DbSet<Serviceprovider> named Serviceproviders
            var searchResult = _context.Serviceproviders
                .Where(s => s.StateId == searchDTO.StateId &&
                            s.CityId == searchDTO.CityId &&
                            s.MainCategoryId == searchDTO.CategoryId)
                .ToList();

            if(searchDTO.SearchString != "All") {
                searchResult = searchResult.Where(s => s.BusinessName.Contains(searchDTO.SearchString)).ToList();
            }
            if (searchDTO.CustomerName != string.Empty && (searchDTO.CustomerEmail != string.Empty || searchDTO.CustomerMobile != string.Empty))
            {
                if (searchDTO.CityId !=0 && searchDTO.CategoryId !=0)
                {
                    // Send Mails to Businesses
                    foreach (var item in searchResult)
                    {
                        var message = "New Lead from Mahanidhi Leads , Customer Name: " + searchDTO.CustomerName + " Contact Number : " + searchDTO.CustomerMobile
                            + " Contact Email : " + searchDTO.CustomerEmail + "</br> Looking for :" +searchDTO.LookingFor;
                        Helper.MailSender.SendLeadsMail(item.Email, message);
                    }
                }
            }

            return searchResult;
        }       
    }
}
