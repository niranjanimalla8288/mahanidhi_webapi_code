using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class OrganizationDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? ContactPerson { get; set; }

        public string? ContactNumber { get; set; }

        public string? SupportNumber { get; set; }

        public string? SupportEmail { get; set; }

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public string? PinCode { get; set; }

        public int? CountryId { get; set; }

        public CityDTO? CityDTO { get; set; }

        public CountryDTO? CountryDTO { get; set; }

        public StateDTO? StateDTO { get; set; }
    }
}
