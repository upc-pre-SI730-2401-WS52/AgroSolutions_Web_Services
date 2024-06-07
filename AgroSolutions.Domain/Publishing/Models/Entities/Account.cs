namespace Domain;

public class Account: ModelBase
{
    public string FullName { get; set; }
    public string Dni { get; set; }
    public string Ruc { get; set; }
    public string CompanyName { get; set; }
    public string EmailAddress { get; set; }
    public string Phone { get; set; }
    public string UserOfType { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public int PendingId { get; set; }
    public List<Pending> PendingList { get; set; }
}