using Microsoft.AspNetCore.Mvc;

namespace TaxaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        [Route("/taxadejuros")]
        public ActionResult TaxaDeJuros()
        {
            return new JsonResult((new Random().NextDouble() <= 0.5 ? 0.01 : 1).ToString("F2"));
        }
    }
}