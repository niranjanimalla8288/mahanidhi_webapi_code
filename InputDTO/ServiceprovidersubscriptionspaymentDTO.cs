using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.InputDTO
{

    public class ServiceprovidersubscriptionspaymentDTO
    {
        public int Id { get; set; }

        public int? ServiceProviderId { get; set; }

        public int? ServiceProviderSubscriptionId { get; set; }

        public decimal? PaidAmount { get; set; }

        public int? PaymentModeId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string? TransactionReference { get; set; }

        public PaymentmodeDTO? PaymentModeDTO { get; set; }

        public ServiceproviderDTO? ServiceProviderDTO { get; set; }

        public ServiceprovidersubscriptionDTO? ServiceProviderSubscriptionDTO { get; set; }
    }
}