using AutoMapper;
using BusinessObject;
using Service.DTOs.AccountDTO;
using Service.DTOs.TutorDTO;
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
            CreateMap<Account, TutorProfileDTO>()
            .ForMember(dest => dest.GeneralProfile, opt => opt.MapFrom(src => src.TutorInformation.GeneralProfile))
            .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.TutorInformation.Language))
            .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.TutorInformation.Degree))
            .ForMember(dest => dest.ExperienceYear, opt => opt.MapFrom(src => src.TutorInformation.ExperienceYear))
            .ForMember(dest => dest.TotalTeachDay, opt => opt.MapFrom(src => src.TutorInformation.TotalTeachDay))
            .ForMember(dest => dest.LowestSalaryPerHour, opt => opt.MapFrom(src => src.TutorInformation.LowestSalaryPerHour))
            .ForMember(dest => dest.HighestSalaryPerHour, opt => opt.MapFrom(src => src.TutorInformation.HighestSalaryPerHour))
            .ForMember(dest => dest.TeachingStyle, opt => opt.MapFrom(src => src.TutorInformation.TeachingStyle))
            .ForMember(dest => dest.TutorCategoryName, opt => opt.MapFrom(src => src.TutorInformation.TutorCategoryId));
            CreateMap<Account, AllAccountDTO>().ReverseMap();
            CreateMap<Account, AllTutorDTO>()
                .ForMember(dest => dest.TutorCategoryName, opt => opt.MapFrom(src => src.TutorInformation.TutorCategory.Name))
                .ReverseMap();
            //tutor information
            CreateMap<TutorInformation, TutorInformationDTO>().ReverseMap();
            //tutor category
            CreateMap<TutorCategory, TutorCategoryDTO>().ReverseMap();
            //certificate
            CreateMap<Certificate, TutorCertificatesDTO>().ReverseMap();

        }
    }
}
