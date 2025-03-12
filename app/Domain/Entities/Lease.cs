using System.ComponentModel.DataAnnotations;

namespace app.Domain.Entities
{
    public class Leases 
    {
        [Key]
        public string LeaseId {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
        public double Rent {get;set;}
        public double Deposit {get;set;}

        public string PropertyId {get;set;}
        public string TenantId {get;set;}

        public Property Property {get;set;}
        public Tenants Tenants {get;set;}
    }
}