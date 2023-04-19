using AutoMapper;
using PopApp.dk.DataAccess.Models;
using PopApp.dk.DataTransferObject.Account;

namespace PopApp.dk.Business.Mapper;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<Account, AccountDTO>().ReverseMap();
        CreateMap<Account, AccountToLoginDTO>().ReverseMap();
        CreateMap<Account, AccountToRegisterDTO>().ReverseMap();
    }
}