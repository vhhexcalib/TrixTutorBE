using AutoMapper;
using BusinessObject;
using Service.DTOs.AccountDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //login
            CreateMap<LoginDTO, SystemAccount>()
                            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                            .ForMember(x => x.Password, opt => opt.MapFrom(x => x.Password));
            CreateMap<LoginDTO, Account>()
                            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                            .ForMember(x => x.Password, opt => opt.MapFrom(x => x.Password));
            //system account
            CreateMap<SystemAccount, CurrentUserObject>().ReverseMap();
            //account
            CreateMap<RegisterAccountDTO, Account>().ReverseMap();
            CreateMap<Account, CurrentUserObject>().ReverseMap();

        }
    }
}
