using System;
using System.Collections.Generic;

namespace MahaanidhiWebAPI.Entities;

public partial class Serviceprovider
{
    public int Id { get; set; }

    public string? BusinessName { get; set; }

    public int? SubCategoryId { get; set; }

    public int? MainCategoryId { get; set; }

    public string? ThumnailImagePath { get; set; }

    public string? Email { get; set; }

    public string? MobileNumber { get; set; }

    public string? WatsAppNumber { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? PinCode { get; set; }

    public string? Gpslocation { get; set; }

    public string? ContactPerson { get; set; }

    public string? Gstnumber { get; set; }

    public string? Cinnumber { get; set; }

    public DateTime? EnrolledDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? YearOfEstablishment { get; set; }

    public string? WorkingHours { get; set; }

    public string? Holidays { get; set; }

    public string? ModesOfPayment { get; set; }

    public float? CurrentRating { get; set; }

    public string? WebsiteLink { get; set; }

    public string? Founded { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public string? StreetViewImageLink { get; set; }

    public string? Desciption { get; set; }

    public string? Title { get; set; }

    public DateTime? Monday { get; set; }

    public DateTime? Tuesday { get; set; }

    public DateTime? Wednesday { get; set; }

    public DateTime? Thursday { get; set; }

    public DateTime? Friday { get; set; }

    public DateTime? Saturday { get; set; }

    public DateTime? Sunday { get; set; }

    public string? Facebook { get; set; }

    public string? TwitterLink { get; set; }

    public string? LinkedinLink { get; set; }

    public string? PintrestLink { get; set; }

    public string? GoogleplusLink { get; set; }

    public string? InstagramLink { get; set; }

    public int? AmenitiesId { get; set; }

    public string? PriceRange { get; set; }

    public int? Views { get; set; }

    public int? PakcageId { get; set; }

    public virtual Amenity? Amenities { get; set; }

    public virtual City? City { get; set; }

    public virtual Serviceprovidercategory? MainCategory { get; set; }

    public virtual Plan? Pakcage { get; set; }

    public virtual ICollection<Serviceproviderbadge> Serviceproviderbadges { get; set; } = new List<Serviceproviderbadge>();

    public virtual ICollection<Serviceproviderbusinesstag> Serviceproviderbusinesstags { get; set; } = new List<Serviceproviderbusinesstag>();

    public virtual ICollection<Serviceproviderservice> Serviceproviderservices { get; set; } = new List<Serviceproviderservice>();

    public virtual ICollection<Serviceprovidersubscription> Serviceprovidersubscriptions { get; set; } = new List<Serviceprovidersubscription>();

    public virtual ICollection<Serviceprovidersubscriptionspayment> Serviceprovidersubscriptionspayments { get; set; } = new List<Serviceprovidersubscriptionspayment>();

    public virtual State? State { get; set; }

    public virtual Serviceprovidersubcategory? SubCategory { get; set; }
}
