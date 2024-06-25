using Presentation.Request;

namespace Domain;

public interface ITeamCommandService
{
    Task<int> Handle(CreateTeamCommand command);
    Task<bool> Handle(DeleteTeamCommand command); 
}