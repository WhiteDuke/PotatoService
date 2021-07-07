using PotatoPlace.Models;
using System.Collections.Generic;

namespace PotatoPlace.Services
{
    /// <summary>
    /// Интерфейс сервиса данных
    /// </summary>
    public interface IPotatoService
    {
        /// <summary>
        /// Добавить данные в хранилище
        /// </summary>
        /// <param name="potato"></param>
        void Add(Potato potato);

        /// <summary>
        /// Удалить данные по идентификатору из хранилища
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Обновить данные по идентификатору в хранилище
        /// </summary>
        /// <param name="id"></param>
        /// <param name="p"></param>
        void Update(int id, Potato p);

        /// <summary>
        /// Получить список данных
        /// </summary>
        /// <returns></returns>
        IEnumerable<Potato> GetList();

        /// <summary>
        /// Получить экземпляр данных по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Potato GetPotato(int id);
    }
}
