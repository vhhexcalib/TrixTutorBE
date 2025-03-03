using AutoMapper;
using AutoMapper.Features;
using BusinessObject;
using Service.DTOs.AccountDTO;
using Service.DTOs.BankDTO;
using Service.DTOs.CategoryDTO;
using Service.DTOs.CoursesDTO;
using Service.DTOs.FeedBackDTO;
using Service.DTOs.OrderDTO;
using Service.DTOs.RoleDTO;
using Service.DTOs.TutorContactDTO;
using Service.DTOs.TutorDTO;

namespace Service.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Login
            CreateMap<LoginDTO, SystemAccount>()
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.Password));

            CreateMap<LoginDTO, Account>()
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.Password));

            // System account
            CreateMap<SystemAccount, CurrentUserObject>().ReverseMap();

            // Account <-> RegisterAccountDTO mapping
            CreateMap<RegisterAccountDTO, Account>()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Birthday)))
                .ReverseMap()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToDateTime(TimeOnly.MinValue)));

            // AllAccountDTO mapping
            CreateMap<Account, AllAccountDTO>()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ReverseMap()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToDateTime(TimeOnly.MinValue)));

            // AllTutorDTO mapping
            CreateMap<Account, AllTutorDTO>()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.TutorInformation.Language))
                .ForMember(dest => dest.TotalTeachDay, opt => opt.MapFrom(src => src.TutorInformation.TotalTeachDay))
                .ForMember(dest => dest.SalaryPerHour, opt => opt.MapFrom(src => src.TutorInformation.SalaryPerHour))
                .ForMember(dest => dest.TutorCategoryName, opt => opt.MapFrom(src => src.TutorInformation.TutorCategory.Name))
                .ForMember(dest => dest.GeneralProfile, opt => opt.MapFrom(src => src.TutorInformation.GeneralProfile)) // Thêm dòng này
                .ReverseMap()
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToDateTime(TimeOnly.MinValue)));

            // Account mappings
            CreateMap<Account, CurrentUserObject>().ReverseMap();
            CreateMap<Account, TutorProfileDTO>()
                .ForMember(dest => dest.GeneralProfile, opt => opt.MapFrom(src => src.TutorInformation.GeneralProfile))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.TutorInformation.Language))
                .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.TutorInformation.Degree))
                .ForMember(dest => dest.ExperienceYear, opt => opt.MapFrom(src => src.TutorInformation.ExperienceYear))
                .ForMember(dest => dest.TotalTeachDay, opt => opt.MapFrom(src => src.TutorInformation.TotalTeachDay))
                .ForMember(dest => dest.SalaryPerHour, opt => opt.MapFrom(src => src.TutorInformation.SalaryPerHour))
                .ForMember(dest => dest.TeachingStyle, opt => opt.MapFrom(src => src.TutorInformation.TeachingStyle))
                .ForMember(dest => dest.TutorCategoryName, opt => opt.MapFrom(src => src.TutorInformation.TutorCategoryId))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.TutorInformation.BankInformation.BankName))
                .ForMember(dest => dest.BankNumber, opt => opt.MapFrom(src => src.TutorInformation.BankInformation.BankNumber))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.TutorInformation.BankInformation.OwnerName)); ;
            // Tutor information
            CreateMap<TutorInformation, TutorInformationDTO>().ReverseMap();

            // Tutor category
            CreateMap<TutorCategory, TutorCategoryDTO>().ReverseMap();

            // Role
            CreateMap<Role, RoleDTO>().ReverseMap();

            // Certificate
            CreateMap<Certificate, TutorCertificatesDTO>().ReverseMap();

            // Bank information
            CreateMap<BankInformation, UpdateBankInformationDTO>().ReverseMap();

            // Feedback
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();

            // Mapping TutorContact <-> TutorContactDTO
            CreateMap<TutorContact, ContactDTO>().ReverseMap();

            //Courses
            CreateMap<Courses, CreateCoursesDTO>().ReverseMap();
            
            // Teaching Time <-> DTO
            CreateMap<TeachingTime, TeachingTimeDTO>().ReverseMap();
            
            // Teaching Date <-> DTO
            CreateMap<TeachingDate, TeachingDateDTO>().ReverseMap();

            // Mapping Courses -> AllCoursesDTO
            CreateMap<Courses, AllCoursesDTO>().ReverseMap();

            // Mapping Courses -> AllCourseByTutorIdDTO
            CreateMap<Courses, AllCourseByTutorIdDTO>().ReverseMap();

            // Mapping Courses -> CourseDetailDTO
            CreateMap<Courses, CourseDetailDTO>()
                .ForMember(dest => dest.TutorName, opt => opt.MapFrom(src => src.TutorInformation.Account.Name))
                .ForMember(dest => dest.TeachingDates, opt => opt.MapFrom(src => src.TeachingDate.TeachingDates))
                .ForMember(dest => dest.TeachingTimes, opt => opt.MapFrom(src => src.TeachingTime.TeachingTimes))
                .ReverseMap();

            // Mapping Orders -> CreateOrderDTO
            CreateMap<Order, CreateOrderDTO>().ReverseMap();

            // Mapping Orders -> StudentOrderDTO
            CreateMap<Order, StudentOrderDTO>().ReverseMap();

        }
    }
}
