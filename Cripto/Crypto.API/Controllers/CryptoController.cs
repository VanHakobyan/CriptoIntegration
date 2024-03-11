using Crypto.API.Integration.Binance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crypto.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CryptoController(IBinanceIntegration integration) : ControllerBase
{
    // GET: api/<CryptoController>
    [HttpGet]
    public IActionResult Get()
    {
        integration.Subscribe();
        return Ok();
    }
}
