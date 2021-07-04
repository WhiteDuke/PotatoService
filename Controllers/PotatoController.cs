using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotatoService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PotatoController : ControllerBase
    {
        private static readonly string[] Sorts = new[]
        {
            "Star", "Violet", "Galla"
        };

        private readonly ILogger<PotatoController> _logger;

        public PotatoController(ILogger<PotatoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Potato> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Potato
            {
                Code = "SRPV",
                CreateDate = DateTime.Now,
                Name = Sorts[index]
            })
            .ToArray();
        }
    }
}