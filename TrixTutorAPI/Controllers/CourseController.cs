using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ISystemAccountService _systemAccountService;
        private readonly IAccountService _accountService;
        private readonly ITutorInformationService _tutorInformationService;
        private readonly ITokenService _tokenService;

        public CourseController(ISystemAccountService systemAccountService, ITokenService tokenService, IAccountService accountService, ITutorInformationService tutorInformationService)
        {
            _systemAccountService = systemAccountService;
            _tokenService = tokenService;
            _accountService = accountService;
            _tutorInformationService = tutorInformationService;
        }
    }
}
