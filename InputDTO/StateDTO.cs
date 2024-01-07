using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class StateDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? CountryId { get; set; }

        public ICollection<CityDTO> CitiesDTO { get; set; } = new List<CityDTO>();

        public CountryDTO? CountryDTO { get; set; }

        public ICollection<OrganizationDTO> OrganizationsDTO { get; set; } = new List<OrganizationDTO>();
    }
}