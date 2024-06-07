using Infraestructure;
using AutoMapper;
using Domain;
using Presentation.Request;

namespace _1_API.Mapper;

public class ModelsToRequest : Profile
{
    public ModelsToRequest()
    {
        CreateMap<Finance, CreateFinanceCommand>();
        CreateMap<PendingCollections, CreatePendingCollections>();
    }
}