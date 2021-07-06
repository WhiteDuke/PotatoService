using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PotatoPlace.Services;
using System;
using System.Collections.Generic;

namespace PotatoPlace.Controllers
{
    [ApiController]
    [Route("potato")]
    public class PotatoController : ControllerBase
    {
        private readonly ILogger<PotatoController> _logger;

        private readonly IPotatoService _potatoService;

        public PotatoController(ILogger<PotatoController> logger, IPotatoService potatoService)
        {
            _logger = logger;
            _potatoService = potatoService;
        }

        /// <summary>
        /// Список данных
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public IEnumerable<Potato> GetPotatoes()
        {
            _logger.LogInformation("::Запрошен список::");
            return _potatoService.GetList();
        }

        /// <summary>
        /// Экземпляр данных
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Potato GetPotato(int id)
        {
            _logger.LogInformation($"::Запрошен экземпляр данных по идентификатору [{id}]::");
            Potato p = _potatoService.GetPotato(id);

            if (p != null)
                return p;
            else
            {
                string msg = $"::Экземпляр данных с идентификатором [{id}] не обнаружен::";
                _logger.LogWarning(msg);
                throw new KeyNotFoundException(msg);
            }
        }

        /// <summary>
        /// Удаление экземпляра данных
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeletePotato(int id)
        {
            _logger.LogInformation($"::Попытка удаления экземпляра данных с идентификатором [{id}]::");

            try
            {
                _potatoService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("add")]
        public void AddPotato(Potato p)
        {
            _logger.LogInformation($"Попытка добавления экземпляра данных");
            if (p == null)
                throw new NullReferenceException("Отсутствуют данные для добавления");

            try
            {
                _potatoService.Add(p);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}