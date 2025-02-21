using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorContactController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ITutorContactService _tutorContactService;
        public TutorContactController(ITokenService tokenService, ITutorContactService tutorContactService)
        {
            _tokenService = tokenService;
            _tutorContactService = tutorContactService;
        }
    }
}
