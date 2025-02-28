namespace app.Domain.Entities
{
    public class RentApplication
    {
        public Guid Id {get;set;}
        public DateTime ApplicationDate {get;set;}
        public string ApplicationStatus {get;set;}

        public string PropertyId {get;set;}
        public string TenantCognito {get;set;}

        public string Name {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string Message {get;set;}

        public Guid LeasedId {get;set;}
       
        public Tenants Tenants {get;set;}
    }
}