using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MahaanidhiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyWordSearchController : ControllerBase
    {

        private readonly MahaanidhieximContext _context;
        private IMapper _mapper;

        public KeyWordSearchController(MahaanidhieximContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       

        // GET api/<KeyWordSearchController>/5
        [HttpGet("{searchWord}")]
        public List<ServiceproviderDTO> Get(string searchWord)
        {
            // Return all Services Privders which startwith or containes the keyword
            var serviceProviders = _context.Serviceproviders.Where(x=>x.BusinessName.Contains(searchWord)).ToList();
            List<ServiceproviderDTO> lstServiceProviderDTOss = _mapper.Map<List<ServiceproviderDTO>>(serviceProviders);
            return lstServiceProviderDTOss;
        }
    }
}
