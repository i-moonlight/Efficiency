using AutoMapper;
using Efficiency.Data.DTO.Store;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class StoreProfile : Profile
{
    public StoreProfile()
    {
        CreateMap<Store, GetStoreDTO>();
        CreateMap<PostStoreDTO, Store>();
        CreateMap<PutStoreDTO, Store>();
    }   
}