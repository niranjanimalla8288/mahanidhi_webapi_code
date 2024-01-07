using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Paymentmode
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Serviceprovidersubscriptionspayment> Serviceprovidersubscriptionspayments { get; set; } = new List<Serviceprovidersubscriptionspayment>();
}
