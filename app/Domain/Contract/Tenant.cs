namespace app.Domain.Contract
{
  public class CreateTenant
  {
    public required string TenantCognitoId {get;set;}
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
  }
  public class TenantReponse
  {
    public string TenantId { get; set; }
    public string TenantCognito { get; set; }
    public string Name { get; set; }
     public string Email { get; set; }
    public string PhoneNumber { get; set; }
  }
}