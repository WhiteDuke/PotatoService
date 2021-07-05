using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotatoPlace.Controllers
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
        public IEnumerable<Potato> GetPotatoes()
        {
            return Enumerable.Range(1, 5).Select(index => new Potato
            {
                Code = $"P{index}",
                CreateDate = DateTime.Now,
                Name = Sorts[index]
            }).ToArray();
        }
    }
}