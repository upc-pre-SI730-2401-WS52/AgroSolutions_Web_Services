namespace Domain;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync();
    
    Task<Employee> GetByIdEmployeeAsync(int id);
    
    Task<Employee> GetByDniEmployeeAsync(string dni);
    
    Task<Employee> GetByTeamIdAdviserEmployeeAsync(int iTeamId);

    Task<List<Employee>> GetByJobEmployeeAsync(string? job, int teamId);
    
    Task<int>  SaveEmployeeAsync(Employee dataEmployee);
       
    Task<bool> DeleteEmployeeAsync(int id); 
}