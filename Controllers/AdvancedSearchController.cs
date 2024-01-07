using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/<AdvancedSearchController>
        //[HttpGet]
        //public IEnumerable<Serviceprovider> Get(AdvancedSearchDTO searchDTO)
        //{
        //    var searchResult = _context.Serviceproviders.Where(s => s.CityId == searchDTO.CityId && s.BusinessName.Contains(searchDTO.SearchString) && s.StateId==searchDTO.StateId && s.MainCategoryId==searchDTO.CategoryId ).ToList();

            
        //    //List<ServiceproviderDTO> serviceProvidersList = new List<ServiceproviderDTO>();
        //    //serviceProvidersList = _mapper.Map<List<ServiceproviderDTO>>(searchResult);

        //    return searchResult;
        //}

        [HttpGet]
        public IEnumerable<Serviceprovider> Get([FromQuery] AdvancedSearchDTO searchDTO)
        {
            // Assuming your DbContext has a DbSet<Serviceprovider> named Serviceproviders
            var searchResult = _context.Serviceproviders
                .Where(s => (!searchDTO.StateId.HasValue || s.StateId == searchDTO.StateId) &&
                            (!searchDTO.CityId.HasValue || s.CityId == searchDTO.CityId) &&
                            (!searchDTO.CategoryId.HasValue || s.MainCategoryId == searchDTO.CategoryId) &&
                            (string.IsNullOrEmpty(searchDTO.SearchString) || s.BusinessName.Contains(searchDTO.SearchString)))
                .ToList();

            return searchResult;
        }
        // GET api/<AdvancedSearchController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdvancedSearchController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "value";
        }

        // PUT api/<AdvancedSearchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdvancedSearchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
