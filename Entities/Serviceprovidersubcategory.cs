using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceprovidersubcategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ParentCategoryId { get; set; }

    public int? MainCategoryId { get; set; }

    public string? ThumnailImagePath { get; set; }

    public virtual ICollection<Serviceprovidersubcategory> InverseParentCategory { get; set; } = new List<Serviceprovidersubcategory>();

    public virtual Serviceprovidercategory? MainCategory { get; set; }

    public virtual Serviceprovidersubcategory? ParentCategory { get; set; }

    public virtual ICollection<Serviceprovider> Serviceproviders { get; set; } = new List<Serviceprovider>();
}
