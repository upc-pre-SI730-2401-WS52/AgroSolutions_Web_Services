using Infraestructure;
using AutoMapper;
using Domain;
using Presentation.Request;

namespace _1_API.Mapper;

public class RequestToModels : Profile
{
    public RequestToModels()
    {
        CreateMap<CreateFinanceCommand, Finance>();
        CreateMap<CreatePendingCollections, PendingCollections>();
    }
}