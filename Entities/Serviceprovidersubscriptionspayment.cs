using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceprovidersubscriptionspayment
{
    public int Id { get; set; }

    public int? ServiceProviderId { get; set; }

    public int? ServiceProviderSubscriptionId { get; set; }

    public decimal? PaidAmount { get; set; }

    public int? PaymentModeId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? TransactionReference { get; set; }

    public virtual Paymentmode? PaymentMode { get; set; }

    public virtual Serviceprovider? ServiceProvider { get; set; }

    public virtual Serviceprovidersubscription? ServiceProviderSubscription { get; set; }
}
