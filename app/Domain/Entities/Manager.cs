using System.ComponentModel.DataAnnotations;

namespace app.Domain.Entities
{
    public class Manager
    {
        [Key]
        public required string ManagerId { get; set; }
        public string ManagerCognitoId {get;set;}
        public required string ManagerName { get; set; }
        public required string ManagerPhone {get;set;}
        public string? ManagerEmail {get;set;}
        
        public List<Property> Properties {get;set;} = new ();
    }
}