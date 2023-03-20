using AutoMapper;
using Efficiency.Data.DTO.Seller;
using Efficiency.Models;

namespace Efficiency.Profiles;

public class SellerProfile : Profile
{
    public SellerProfile()
    {
        CreateMap<Seller, GetSellerDTO>();
        CreateMap<PostSellerDTO, Seller>();
        CreateMap<PutSellerDTO, Seller>();
    }   
}