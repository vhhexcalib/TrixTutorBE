using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace TrixTutorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ITokenService _tokenService;

        public ReportController(ITokenService tokenService, IReportService reportService)
        {
            _tokenService = tokenService;
            _reportService = reportService;
        }

    }
}
