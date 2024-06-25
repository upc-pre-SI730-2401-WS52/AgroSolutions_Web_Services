namespace Domain;

public class Team : ModelBase
{
    public string TeamCode { get; set; }
    public decimal Budget { get; set; }
    public string CropCode { get; set; }
    
    public List<Employee> EmployeeId { get; set; }
    public List<Employee> OperatorsList { get; set; }
}