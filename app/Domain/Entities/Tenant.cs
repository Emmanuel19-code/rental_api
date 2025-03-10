using System.ComponentModel.DataAnnotations;

namespace app.Domain.Entities
{
    public class Tenants
    {
        [Key]
        public string TenantId {get;set;}
        public string TenantCognitoId {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        
        public Leases Leases {get;set;}
    }
}