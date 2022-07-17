using Domain.Services.Interfaces;
using Domain.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Calculos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoController : ControllerBase
    {
        private readonly IDomainService _domainService;

        public CalculoController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        [HttpGet]
        [Route("/calculajuros")]
        public async Task<IActionResult> CalculaJuros([FromQuery] JurosViewModel juros)
        {
            try
            {
                var result = await _domainService.CalcularJurosAsync(juros);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = $"Erro inesperado: {e.Message}" });
            }
        }

        [HttpGet]
        [Route("/showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            var result = "https://github.com/salazarleonidas/teste-granito";
            return Ok(result);
        }
    }
}