using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class ServiceproviderbusinesstagDTO
    {
        public int Id { get; set; }

        public int? ServiceProviderId { get; set; }

        public int? BusinessTagId { get; set; }

        public BusinesstagDTO? BusinessTagDTO { get; set; }

        public ServiceproviderDTO? ServiceProviderDTO{ get; set; }
    }
}