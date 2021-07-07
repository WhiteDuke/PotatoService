using Microsoft.AspNetCore.Mvc;

namespace PotatoPlace.Controllers
{
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}