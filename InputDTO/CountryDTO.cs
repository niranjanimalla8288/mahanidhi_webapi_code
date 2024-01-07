using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MahaanidhiWebAPI.InputDTO
{

    public class CountryDTO
    {
       
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? CurrencyCode { get; set; }

        public string? TelecomeCode { get; set; }

        public string? CurrencySymbol { get; set; }

        public ICollection<OrganizationDTO> OrganizationsDTO { get; set; } = new List<OrganizationDTO>();

        public ICollection<StateDTO> StatesDTO { get; set; } = new List<StateDTO>();
    }
}