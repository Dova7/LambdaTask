using Application.Models.Identity.Dtos;
using Application.Models.Main.Dtos.Balances;
using Application.Models.Main.Dtos.Games;
using Application.Models.Main.Dtos.Ledgers;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;

namespace Application.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationRequestDto, ApplicationUser>()
                .ForMember(u => u.DisplayName, opt => opt.MapFrom((src, _) => string.IsNullOrWhiteSpace(src.DisplayName)
                       ? src.UserName
                       : src.DisplayName))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(d => d.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(d => d.LastName))
                .ForMember(u => u.Email, opt => opt.MapFrom(d => d.Email))
                .ForMember(u => u.UserName, opt => opt.MapFrom(d => d.UserName))
                .ForMember(u => u.PhoneNumber, opt => opt.MapFrom(d => d.PhoneNumber));



            CreateMap<ApplicationUser, GetAllUsersDto>().ReverseMap();
            CreateMap<ApplicationUser, GetUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserInfoDto>().ReverseMap();

            CreateMap<Balance, AddBalanceDto>().ReverseMap();
            CreateMap<Balance, GetAllBalancesDto>().ReverseMap();
            CreateMap<Balance, GetBalanceInfoDto>().ReverseMap();
            CreateMap<Balance, AddToBalanceDto>().ReverseMap();
            CreateMap<Balance, WithdrawFromBalanceDto>().ReverseMap();


            CreateMap<LedgerEntry, AddLedgerDto>().ReverseMap();
            CreateMap<LedgerEntry, GetAllLedgersDto>().ReverseMap();

            CreateMap<Game, GetAllGamesDto>().ReverseMap();
        }
    }
}
