using Infrastracture.Repository;
using InQuiry.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InQuiry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IBalanceService _balanceService;

        public ApiController(ILogger<ApiController> logger, IBalanceService balanceService)
        {
            _logger = logger;
            _balanceService = balanceService;
        }

        [HttpGet("[action]")]
        public async Task<APIResult<List<BalanceDto>>> GetApi([FromQuery] string address)
        {
            var _result = new APIResult<List<BalanceDto>>();
            try
            {
                _result = await _balanceService.GetApiAsync(address);
            }
            catch (Exception ex)
            {
                _result.Success = false;
                _result.Messages = new List<string>() { ex.ToString() };
            }
            return _result;
        }
    }
}
