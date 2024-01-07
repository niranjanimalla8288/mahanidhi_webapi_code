using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO {

    public class ServiceproviderbadgeDTO
    {
        public int Id { get; set; }

        public int? ServiceProviderId { get; set; }

        public int? BadgeId { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool? IsVoid { get; set; }

        public BadgeDTO? Badge { get; set; }

        public ServiceproviderDTO? ServiceProviderDTO { get; set; }
    }
}
