using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class ServiceprovidersubscriptionDTO
    {
        public int Id { get; set; }

        public int? ServiceProviderId { get; set; }

        public int? PlanId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? ContractDocPath { get; set; }

        public decimal? SubscriptionAmount { get; set; }

        public int? ListingPosition { get; set; }

        public PlanDTO? Plan { get; set; }

        public ServiceproviderDTO? ServiceProviderDTO { get; set; }

        public ICollection<ServiceprovidersubscriptionspaymentDTO> ServiceprovidersubscriptionspaymentsDTO { get; set; } = new List<ServiceprovidersubscriptionspaymentDTO>();
    }
}