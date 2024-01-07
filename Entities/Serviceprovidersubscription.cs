using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceprovidersubscription
{
    public int Id { get; set; }

    public int? ServiceProviderId { get; set; }

    public int? PlanId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? ContractDocPath { get; set; }

    public decimal? SubscriptionAmount { get; set; }

    public int? ListingPosition { get; set; }

    public virtual Plan? Plan { get; set; }

    public virtual Serviceprovider? ServiceProvider { get; set; }

    public virtual ICollection<Serviceprovidersubscriptionspayment> Serviceprovidersubscriptionspayments { get; set; } = new List<Serviceprovidersubscriptionspayment>();
}
