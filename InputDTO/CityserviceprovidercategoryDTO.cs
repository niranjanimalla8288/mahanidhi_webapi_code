using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class CityserviceprovidercategoryDTO
    {
        public int Id { get; set; }

        public int? CityId { get; set; }

        public int? ServiceProviderCategoryId { get; set; }

        //public CityDTO? CityDTO { get; set; }

        //public ServiceprovidercategoryDTO? ServiceProviderCategoryDTO { get; set; }
    }
}