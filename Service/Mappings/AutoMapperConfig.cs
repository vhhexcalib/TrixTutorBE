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
            CreateMap<LoginDTO, SystemAccount>()
                            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                            .ForMember(x => x.Password, opt => opt.MapFrom(x => x.Password));
            CreateMap<SystemAccount, CurrentUserObject>().ReverseMap();
        }
    }
}
