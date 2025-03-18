namespace app.Domain.Contract
{
  public class UpdateManager
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
  }
  public class ManagerReponse
  {
    public required string ManagerId { get; set; }
    public string ManagerCognitoId { get; set; }
    public required string ManagerName { get; set; }
    public required string ManagerPhone { get; set; }
    public string? ManagerEmail { get; set; }
  }
  public class AddManager
  {
    public required string CognitoId {get;set;}
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }

  }
}