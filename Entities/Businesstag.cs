using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Businesstag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Serviceproviderbusinesstag> Serviceproviderbusinesstags { get; set; } = new List<Serviceproviderbusinesstag>();
}
