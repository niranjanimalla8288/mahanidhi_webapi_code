using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Cityserviceprovidercategory
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public int? ServiceProviderCategoryId { get; set; }

    public virtual City? City { get; set; }

    public virtual Serviceprovidercategory? ServiceProviderCategory { get; set; }
}
