using Domain;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AuthenticationService AuthenticationService;
        public CurrencyController()
        {
            this.AuthenticationService = new AuthenticationService();
        }

        [HttpPost("Login")]
        public Response Login([FromBody] User loginUser)
        {
            Response Response = AuthenticationService.ValidateUser(loginUser);
            return Response;
        }

        [HttpGet("Currencies")]
        public Response Currencies()
        {
            GetCurrencies getCurrencies = new ();
            return getCurrencies.Process();
        }

        [HttpPost("Convert")]
        public Response Convert([FromBody] ConvertRequest request)
        {
            ConvertHelper ConvertHelper = new ();
            return ConvertHelper.Process(request.TargetCurrency, request.Value);
        }

    }
}
