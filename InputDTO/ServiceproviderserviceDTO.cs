using MahaanidhiWebAPI.Entities;
using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class ServiceproviderserviceDTO
    {
        public int Id { get; set; }

        public int? ServiceProviderCategoryServicesId { get; set; }

        public int? ServiceProviderId { get; set; }

        public string? ThumnailImagePath { get; set; }

       
    }
}
