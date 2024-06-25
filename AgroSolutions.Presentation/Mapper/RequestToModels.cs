using Infraestructure;
using AutoMapper;
using Domain;
using LearningCenter.Domain.IAM.Models.Comands;
using Presentation.Request;

namespace _1_API.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<CreateFinanceCommand, Finance>();
        CreateMap<CreatePendingCollections, PendingCollections>();
        CreateMap<CreateAdviserCommand, Adviser>();
        CreateMap<CreateCropsCommand, Crop>();
        CreateMap<CreateCalendarCommand, Calendar>();
        CreateMap<SingupCommand, User>();
        CreateMap<SigninCommand, User>();
        CreateMap<CreatePendingCommand, Pending>();

    }
}