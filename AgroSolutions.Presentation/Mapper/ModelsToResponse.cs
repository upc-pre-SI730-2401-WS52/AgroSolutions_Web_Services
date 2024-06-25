using _1_API.Response;
using Infraestructure;
using AutoMapper;
using Domain;

namespace _1_API.Mapper;

public class ModelsToResponse : Profile
{
    public ModelsToResponse()
    {
        CreateMap<Finance, FinanceResponse>();
        CreateMap<PendingCollections, PendingCollectionsResponse>();
        CreateMap<Crop, CropsResponse>();
        CreateMap<Adviser, AdviserResponse>();
        CreateMap<Calendar, CalendarResponse>();
        CreateMap<User, UserResponse>();
        CreateMap<Pending, PendingResponse>();
        CreateMap<Employee, EmployeeResponse>();
        CreateMap<Employee, EmployeShortResponse>();
        CreateMap<Employee, JobsResponse>();
    }
}