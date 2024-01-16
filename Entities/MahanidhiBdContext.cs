using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MahaanidhiWebAPI.Entities;

public partial class MahaanidhieximContext : DbContext
{
    public MahaanidhieximContext()
    {
    }

    public MahaanidhieximContext(DbContextOptions<MahaanidhieximContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Add> Adds { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<BusinessRegistration> BusinessRegistrations { get; set; }

    public virtual DbSet<Businesstag> Businesstags { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Cityarea> Cityareas { get; set; }

    public virtual DbSet<Cityserviceprovidercategory> Cityserviceprovidercategories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customfield> Customfields { get; set; }

    public virtual DbSet<LeadPosition> LeadPositions { get; set; }

    public virtual DbSet<LeadspositionRange> LeadspositionRanges { get; set; }

    public virtual DbSet<LeadsSent> LeadsSents{ get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Paymentmode> Paymentmodes { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Register> Registers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Serviceprovider> Serviceproviders { get; set; }

    public virtual DbSet<Serviceproviderbadge> Serviceproviderbadges { get; set; }

    public virtual DbSet<Serviceproviderbusinesstag> Serviceproviderbusinesstags { get; set; }

    public virtual DbSet<Serviceprovidercategory> Serviceprovidercategories { get; set; }

    public virtual DbSet<Serviceprovidercategoryservice> Serviceprovidercategoryservices { get; set; }

    public virtual DbSet<Serviceproviderreview> Serviceproviderreviews { get; set; }

    public virtual DbSet<Serviceproviderservice> Serviceproviderservices { get; set; }

    public virtual DbSet<Serviceprovidersubcategory> Serviceprovidersubcategories { get; set; }

    public virtual DbSet<Serviceprovidersubscription> Serviceprovidersubscriptions { get; set; }

    public virtual DbSet<Serviceprovidersubscriptionspayment> Serviceprovidersubscriptionspayments { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=mahanidhi_bd");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Add>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adds");

            entity.HasIndex(e => e.CityId, "add_table_foreign_key_1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddImage).HasColumnName("add_image");
            entity.Property(e => e.AddPlace)
                .HasMaxLength(45)
                .HasColumnName("add_place");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryId");
            entity.Property(e => e.FromDate)
                .HasColumnType("date")
                .HasColumnName("from_date");
            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("to_date");

            entity.HasOne(d => d.City).WithMany(p => p.Adds)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("add_table_foreign_key_1");

            entity.HasOne(d=>d.Serviceprovidercategory).WithMany(p=>p.Adds)
            .HasForeignKey(d=>d.CategoryId)
            .HasConstraintName("add_table_foreign_key_2");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("amenities");

            entity.Property(e => e.Options).HasMaxLength(100);
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("badges");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<BusinessRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("business_registration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .HasColumnName("companyName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Businesstag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("businesstags");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cities");

            entity.HasIndex(e => e.StateId, "StateId");

            entity.Property(e => e.Gpslocation)
                .HasMaxLength(255)
                .HasColumnName("GPSLocation");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.State).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("cities_ibfk_1");
        });

        modelBuilder.Entity<Cityarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cityareas");

            entity.HasIndex(e => e.CityId, "CityId");

            entity.Property(e => e.Gpslocation)
                .HasMaxLength(255)
                .HasColumnName("GPSLocation");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PinCode).HasMaxLength(10);

            entity.HasOne(d => d.City).WithMany(p => p.Cityareas)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("cityareas_ibfk_1");
        });

        modelBuilder.Entity<Cityserviceprovidercategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cityserviceprovidercategories");

            entity.HasIndex(e => e.CityId, "CityId");

            entity.HasIndex(e => e.ServiceProviderCategoryId, "ServiceProviderCategoryId");

            entity.HasOne(d => d.City).WithMany(p => p.Cityserviceprovidercategories)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("cityserviceprovidercategories_ibfk_1");

            entity.HasOne(d => d.ServiceProviderCategory).WithMany(p => p.Cityserviceprovidercategories)
                .HasForeignKey(d => d.ServiceProviderCategoryId)
                .HasConstraintName("cityserviceprovidercategories_ibfk_2");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contacts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .HasColumnName("message");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Subject)
                .HasMaxLength(300)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CurrencyCode).HasMaxLength(10);
            entity.Property(e => e.CurrencySymbol).HasMaxLength(5);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.TelecomeCode).HasMaxLength(10);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LoginOtp)
                .HasMaxLength(10)
                .HasColumnName("LoginOTP");
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(45);
        });

        modelBuilder.Entity<Customfield>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customfields");

            entity.Property(e => e.FieldName).HasMaxLength(50);
            entity.Property(e => e.FieldTitle).HasMaxLength(50);
            entity.Property(e => e.HelpText).HasMaxLength(50);
            entity.Property(e => e.Options).HasMaxLength(50);
            entity.Property(e => e.ShowInDetail).HasMaxLength(100);
            entity.Property(e => e.ShowInSearch).HasMaxLength(100);
            entity.Property(e => e.SortOrder).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<LeadPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lead_positions");

            entity.HasIndex(e => new { e.CityId, e.ServiceProviderId }, "lead_position_foreignkey_1_idx");

            entity.HasIndex(e => e.CategoryId, "lead_position_foreignkey_2_idx");

            entity.HasIndex(e => e.LeadpositionRangeId, "lead_position_foreignkey_3_idx");

            entity.HasIndex(e => e.ServiceProviderId, "lead_position_foreignkey_4_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.FromDate)
                .HasColumnType("date")
                .HasColumnName("from_date");
            entity.Property(e => e.LeadpositionRangeId).HasColumnName("leadposition_range_id");
            entity.Property(e => e.ServiceProviderId).HasColumnName("service_provider_id");
            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("to_date");
        });

        modelBuilder.Entity<LeadspositionRange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("leadsposition_ranges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PositionFrom)
                .HasColumnType("date")
                .HasColumnName("position_from");
            entity.Property(e => e.PositionName)
                .HasMaxLength(45)
                .HasColumnName("position_name");
            entity.Property(e => e.PositionTo)
                .HasColumnType("date")
                .HasColumnName("position_to");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("offers");

            entity.Property(e => e.ActivationDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedTime).HasColumnType("datetime");
            entity.Property(e => e.LongText)
                .HasMaxLength(100)
                .HasColumnName("Long_Text");
            entity.Property(e => e.PublishTime).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(20);
        });

        modelBuilder.Entity<LeadsSent>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY"); 
            entity.ToTable("leadssent");
            entity.HasIndex(e => e.LeadsSubscriptionId, "LeadsSubscriptionId");
            entity.HasIndex(e => e.WhatsappMessageSentId, "WhatsappMessageSentId");
            entity.HasIndex(e => e.MessagesSentId, "MessagesSentId");

        });
        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("organization");

            entity.HasIndex(e => e.CityId, "CityId");

            entity.HasIndex(e => e.CountryId, "CountryId");

            entity.HasIndex(e => e.StateId, "StateId");

            entity.Property(e => e.AddressLine1).HasMaxLength(255);
            entity.Property(e => e.AddressLine2).HasMaxLength(255);
            entity.Property(e => e.AddressLine3).HasMaxLength(255);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.ContactPerson).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PinCode).HasMaxLength(10);
            entity.Property(e => e.SupportEmail).HasMaxLength(255);
            entity.Property(e => e.SupportNumber).HasMaxLength(20);

            entity.HasOne(d => d.City).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("organization_ibfk_2");

            entity.HasOne(d => d.Country).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("organization_ibfk_3");

            entity.HasOne(d => d.State).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("organization_ibfk_1");
        });

        modelBuilder.Entity<Paymentmode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paymentmodes");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("plans");

            entity.Property(e => e.Cost).HasPrecision(10);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ServiceDescription)
                .HasMaxLength(250)
                .HasColumnName("Service_Description");
        });

        modelBuilder.Entity<Register>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("register");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(255);
            entity.Property(e => e.MobileNumber).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Serviceprovider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceproviders");

            entity.HasIndex(e => e.MainCategoryId, "MainCategoryId");

            entity.HasIndex(e => e.SubCategoryId, "SubCategoryId");

            entity.HasIndex(e => e.PakcageId, "serviceprovider_foreignKey_idx");

            entity.HasIndex(e => e.CityId, "serviceproviders_ibfk_3_idx");

            entity.HasIndex(e => e.AmenitiesId, "serviceproviders_ibfk_4_idx");

            entity.HasIndex(e => e.StateId, "serviceproviders_ibfk_4_idx1");

            entity.HasIndex(e => e.Title, "serviceproviders_ibfk_6_idx1");

            entity.Property(e => e.AddressLine1).HasMaxLength(255);
            entity.Property(e => e.AddressLine2).HasMaxLength(255);
            entity.Property(e => e.AddressLine3).HasMaxLength(255);
            entity.Property(e => e.BusinessName).HasMaxLength(255);
            entity.Property(e => e.Cinnumber)
                .HasMaxLength(20)
                .HasColumnName("CINNumber");
            entity.Property(e => e.CityId).HasColumnName("City_Id");
            entity.Property(e => e.ContactPerson).HasMaxLength(255);
            entity.Property(e => e.Desciption).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EnrolledDate).HasColumnType("date");
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.Facebook)
                .HasMaxLength(255)
                .HasColumnName("facebook");
            entity.Property(e => e.Founded).HasMaxLength(45);
            entity.Property(e => e.Friday).HasColumnType("date");
            entity.Property(e => e.GoogleplusLink)
                .HasMaxLength(255)
                .HasColumnName("googleplus_link");
            entity.Property(e => e.Gpslocation)
                .HasMaxLength(255)
                .HasColumnName("GPSLocation");
            entity.Property(e => e.Gstnumber)
                .HasMaxLength(20)
                .HasColumnName("GSTNumber");
            entity.Property(e => e.Holidays).HasMaxLength(255);
            entity.Property(e => e.InstagramLink)
                .HasMaxLength(255)
                .HasColumnName("instagram_link");
            entity.Property(e => e.LinkedinLink)
                .HasMaxLength(255)
                .HasColumnName("linkedin_link");
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.ModesOfPayment).HasMaxLength(255);
            entity.Property(e => e.Monday).HasColumnType("date");
            entity.Property(e => e.PakcageId).HasColumnName("pakcageId");
            entity.Property(e => e.PinCode).HasMaxLength(10);
            entity.Property(e => e.PintrestLink)
                .HasMaxLength(255)
                .HasColumnName("pintrest_link");
            entity.Property(e => e.PriceRange)
                .HasMaxLength(45)
                .HasColumnName("price_range");
            entity.Property(e => e.Saturday).HasColumnType("date");
            entity.Property(e => e.StateId).HasColumnName("State_Id");
            entity.Property(e => e.StreetViewImageLink)
                .HasMaxLength(45)
                .HasColumnName("Street_view_image_link");
            entity.Property(e => e.Sunday).HasColumnType("date");
            entity.Property(e => e.Thursday).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(45);
            entity.Property(e => e.Tuesday).HasColumnType("date");
            entity.Property(e => e.TwitterLink)
                .HasMaxLength(255)
                .HasColumnName("twitter_link");
            entity.Property(e => e.Views).HasColumnName("views");
            entity.Property(e => e.WatsAppNumber).HasMaxLength(20);
            entity.Property(e => e.WebsiteLink)
                .HasMaxLength(45)
                .HasColumnName("Website_link");
            entity.Property(e => e.Wednesday).HasColumnType("date");
            entity.Property(e => e.WorkingHours).HasMaxLength(255);

            entity.HasOne(d => d.Amenities).WithMany(p => p.Serviceproviders)
                .HasForeignKey(d => d.AmenitiesId)
                .HasConstraintName("serviceproviders_ibfk_4");

            entity.HasOne(d => d.City).WithMany(p => p.Serviceproviders)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("serviceproviders_ibfk_3");

            entity.HasOne(d => d.MainCategory).WithMany(p => p.Serviceproviders)
                .HasForeignKey(d => d.MainCategoryId)
                .HasConstraintName("serviceproviders_ibfk_2");

            entity.HasOne(d => d.Pakcage).WithMany(p => p.Serviceproviders)
                .HasForeignKey(d => d.PakcageId)
                .HasConstraintName("serviceprovider_foreignKey");

            entity.HasOne(d => d.State).WithMany(p => p.Serviceproviders)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("serviceproviders_ibfk_5");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Serviceproviders)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("serviceproviders_ibfk_1");
        });

        modelBuilder.Entity<Serviceproviderbadge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceproviderbadges");

            entity.HasIndex(e => e.BadgeId, "BadgeId");

            entity.HasIndex(e => e.ServiceProviderId, "ServiceProviderId");

            entity.Property(e => e.ExpiryDate).HasColumnType("date");

            entity.HasOne(d => d.Badge).WithMany(p => p.Serviceproviderbadges)
                .HasForeignKey(d => d.BadgeId)
                .HasConstraintName("serviceproviderbadges_ibfk_2");

            entity.HasOne(d => d.ServiceProvider).WithMany(p => p.Serviceproviderbadges)
                .HasForeignKey(d => d.ServiceProviderId)
                .HasConstraintName("serviceproviderbadges_ibfk_1");
        });

        modelBuilder.Entity<Serviceproviderbusinesstag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceproviderbusinesstags");

            entity.HasIndex(e => e.BusinessTagId, "BusinessTagId");

            entity.HasIndex(e => e.ServiceProviderId, "ServiceProviderId");

            entity.HasOne(d => d.BusinessTag).WithMany(p => p.Serviceproviderbusinesstags)
                .HasForeignKey(d => d.BusinessTagId)
                .HasConstraintName("serviceproviderbusinesstags_ibfk_2");

            entity.HasOne(d => d.ServiceProvider).WithMany(p => p.Serviceproviderbusinesstags)
                .HasForeignKey(d => d.ServiceProviderId)
                .HasConstraintName("serviceproviderbusinesstags_ibfk_1");
        });

        modelBuilder.Entity<Serviceprovidercategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceprovidercategories");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Serviceprovidercategoryservice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceprovidercategoryservices");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Serviceproviderreview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceproviderreviews");

            entity.HasIndex(e => e.CustomerId, "CustomerId");

            entity.HasIndex(e => e.ServiceProviderId, "serviceproviderreviews_ibfk_1_idx");

            entity.Property(e => e.ReviewDate).HasColumnType("date");
            entity.Property(e => e.ReviewDescription).HasColumnType("text");
            entity.Property(e => e.ReviewTitle).HasMaxLength(255);

            //entity.HasOne(d => d.Customer).WithMany(p => p.Serviceproviderreviews)
            //    .HasForeignKey(d => d.CustomerId)
            //    .HasConstraintName("serviceproviderreviews_ibfk_1");
        });

        modelBuilder.Entity<Serviceproviderservice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceproviderservices");

            entity.HasIndex(e => e.ServiceProviderId, "ServiceProviderId");

            entity.HasIndex(e => e.ServiceProviderCategoryServicesId, "serviceproviderservices_ibfk_1");

            entity.HasOne(d => d.ServiceProviderCategoryServices).WithMany(p => p.Serviceproviderservices)
                .HasForeignKey(d => d.ServiceProviderCategoryServicesId)
                .HasConstraintName("serviceproviderservices_ibfk_1");

            entity.HasOne(d => d.ServiceProvider).WithMany(p => p.Serviceproviderservices)
                .HasForeignKey(d => d.ServiceProviderId)
                .HasConstraintName("serviceproviderservices_ibfk_2");
        });

        modelBuilder.Entity<Serviceprovidersubcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceprovidersubcategories");

            entity.HasIndex(e => e.MainCategoryId, "MainCategoryId");

            entity.HasIndex(e => e.ParentCategoryId, "ParentCategoryId");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.MainCategory).WithMany(p => p.Serviceprovidersubcategories)
                .HasForeignKey(d => d.MainCategoryId)
                .HasConstraintName("serviceprovidersubcategories_ibfk_2");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("serviceprovidersubcategories_ibfk_1");
        });

        modelBuilder.Entity<Serviceprovidersubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceprovidersubscriptions");

            entity.HasIndex(e => e.PlanId, "PlanId");

            entity.HasIndex(e => e.ServiceProviderId, "ServiceProviderId");

            entity.Property(e => e.ContractDocPath).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.SubscriptionAmount).HasPrecision(10);

            entity.HasOne(d => d.Plan).WithMany(p => p.Serviceprovidersubscriptions)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("serviceprovidersubscriptions_ibfk_2");

            entity.HasOne(d => d.ServiceProvider).WithMany(p => p.Serviceprovidersubscriptions)
                .HasForeignKey(d => d.ServiceProviderId)
                .HasConstraintName("serviceprovidersubscriptions_ibfk_1");
        });

        modelBuilder.Entity<Serviceprovidersubscriptionspayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("serviceprovidersubscriptionspayments");

            entity.HasIndex(e => e.PaymentModeId, "PaymentModeId");

            entity.HasIndex(e => e.ServiceProviderId, "ServiceProviderId");

            entity.HasIndex(e => e.ServiceProviderSubscriptionId, "ServiceProviderSubscriptionId");

            entity.Property(e => e.PaidAmount).HasPrecision(10);
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.TransactionReference).HasMaxLength(255);

            entity.HasOne(d => d.PaymentMode).WithMany(p => p.Serviceprovidersubscriptionspayments)
                .HasForeignKey(d => d.PaymentModeId)
                .HasConstraintName("serviceprovidersubscriptionspayments_ibfk_3");

            entity.HasOne(d => d.ServiceProvider).WithMany(p => p.Serviceprovidersubscriptionspayments)
                .HasForeignKey(d => d.ServiceProviderId)
                .HasConstraintName("serviceprovidersubscriptionspayments_ibfk_1");

            entity.HasOne(d => d.ServiceProviderSubscription).WithMany(p => p.Serviceprovidersubscriptionspayments)
                .HasForeignKey(d => d.ServiceProviderSubscriptionId)
                .HasConstraintName("serviceprovidersubscriptionspayments_ibfk_2");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("states");

            entity.HasIndex(e => e.CountryId, "CountryId");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Country).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("states_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(255);
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("userroles");

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.HasOne(d => d.Role).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("userroles_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userroles_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
