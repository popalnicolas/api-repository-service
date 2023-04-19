using AutoMapper;
using POPAPP.DK.DATA.Models;
using POPAPP.DK.DTO.Account;

namespace POPAPP.DK.BUSINESS.Mapper;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<Account, AccountDTO>().ReverseMap();
        CreateMap<Account, AccountToLoginDTO>().ReverseMap();
        CreateMap<Account, AccountToRegisterDTO>().ReverseMap();
    }
}