using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class CustomerDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? MobileNumber { get; set; }

        public DateTime? LastLogin { get; set; }

        public string? LoginOtp { get; set; }

        public ICollection<ServiceproviderreviewDTO> ServiceproviderreviewsDTO { get; set; } = new List<ServiceproviderreviewDTO>();
    }
}