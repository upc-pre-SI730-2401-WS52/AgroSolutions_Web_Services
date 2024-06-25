namespace Domain;


public interface ITeamRepository
{
    Task<List<Team>> GetAllTeamAsync();
    
    Task<Team> GetByIdTeamAsync(int id);
    
    Task<Team> GetByTeamCodeAsync(string teamCode);
    
    Task<Team> GetByCropCodeAsync(string cropCode);

    Task<Team> GetByAdviserCodeAsync(string adviser);
    
    Task<int>  SaveTeamAsync(Team dataTeam);
    
    Task<bool> DeleteTeamAsync(int id);
}