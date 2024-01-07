using AutoMapper;
using MahaanidhiWebAPI.Entities;
using MahaanidhiWebAPI.InputDTO;

namespace MahaanidhiWebAPI.Mappers
{
    public class GlobalMapper : Profile
    { 
    //    public class MyOwnClass
    //    {
    //        public string Name { get; set; }        
    //    }
             
        public GlobalMapper()
        {
            CreateMap<Amenity, AmenityDTO>();
            CreateMap<AmenityDTO, Amenity>();

            CreateMap<Add, AddDTO>();
            CreateMap<AddDTO, Add>();

            CreateMap<Badge, BadgeDTO>();
            CreateMap<BadgeDTO, Badge>();

            CreateMap<Businesstag, BusinesstagDTO>();
            CreateMap<BusinesstagDTO, Businesstag>();

            CreateMap<BusinessRegistration , BusinessRegistrationDTO>();
            CreateMap<BusinessRegistrationDTO, BusinessRegistration>();

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<Cityarea, CityareaDTO>();
            CreateMap<CityareaDTO, Cityarea>();

            CreateMap<Cityserviceprovidercategory, CityserviceprovidercategoryDTO>();
            CreateMap<CityserviceprovidercategoryDTO, Cityserviceprovidercategory>();

            CreateMap<CountryDTO, Country>();
            CreateMap<Country, CountryDTO>();

            CreateMap<Customfield, CustomfieldDTO>();
            CreateMap<CustomfieldDTO, Customfield>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Offer, OfferDTO>();
            CreateMap<OfferDTO, Offer>();

            CreateMap<Serviceproviderreview, ServiceproviderreviewDTO>();
            CreateMap<ServiceproviderreviewDTO, Serviceproviderreview>();

            CreateMap<Organization, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organization>();

            CreateMap<Paymentmode, PaymentmodeDTO>();
            CreateMap<PaymentmodeDTO, Paymentmode>();

            CreateMap<Plan, PlanDTO>();
            CreateMap<PlanDTO, Plan>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>();

            CreateMap<LeadPosition, LeadpositionDTO>();
            CreateMap<LeadpositionDTO, LeadPosition>();

            CreateMap<LeadspositionRange, LeadpositionrangeDTO>();
            CreateMap<LeadpositionrangeDTO, LeadspositionRange>();

            CreateMap<Serviceproviderbadge, ServiceproviderbadgeDTO>();
            CreateMap<ServiceproviderbadgeDTO, Serviceproviderbadge>();

            CreateMap<Serviceproviderbusinesstag, ServiceproviderbusinesstagDTO>();
            CreateMap<ServiceproviderbusinesstagDTO, Serviceproviderbusinesstag>();

            CreateMap<ServiceprovidercategoryDTO, Serviceprovidercategory>();
            CreateMap<Serviceprovidercategory, ServiceprovidercategoryDTO>();

            CreateMap<ServiceproviderDTO, Serviceprovider>();
            CreateMap<Serviceprovider, ServiceproviderDTO>();

            CreateMap<ServiceprovidercategoryserviceDTO, Serviceprovidercategoryservice>();
            CreateMap<Serviceprovidercategoryservice, ServiceprovidercategoryserviceDTO>();

            CreateMap<ServiceproviderreviewDTO, Serviceproviderreview>();
            CreateMap<Serviceproviderreview, ServiceproviderreviewDTO>();

            CreateMap<ServiceproviderserviceDTO, Serviceproviderservice>();
            CreateMap<Serviceproviderservice, ServiceproviderserviceDTO>();

            CreateMap<ServiceprovidersubcategoryDTO, Serviceprovidersubcategory>();
            CreateMap<Serviceprovidersubcategory, ServiceprovidersubcategoryDTO>();

            CreateMap<ServiceprovidersubscriptionDTO, Serviceprovidersubscription>();
            CreateMap<Serviceprovidersubscription, ServiceprovidersubscriptionDTO>();

            CreateMap<ServiceprovidersubscriptionspaymentDTO, Serviceprovidersubscriptionspayment>();
            CreateMap<Serviceprovidersubscriptionspayment, ServiceprovidersubscriptionspaymentDTO>();

            CreateMap<StateDTO, State>();
            CreateMap<State, StateDTO>();

            CreateMap<User, UserDTO>();
            CreateMap<Userrole, UserroleDTO>();
        }
    }
}
