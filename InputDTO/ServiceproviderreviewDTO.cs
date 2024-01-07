using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO {

    public class ServiceproviderreviewDTO
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? ServiceProviderId { get; set; }

        public string? ReviewDescription { get; set; }

        public string? ReviewTitle { get; set; }

        public int? Rating { get; set; }

        public DateTime? ReviewDate { get; set; }

        public CustomerDTO? CustomerDTO { get; set; }

        public ServiceproviderDTO? ServiceProviderDTO { get; set; }
    }
}
