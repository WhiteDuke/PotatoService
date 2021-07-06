using System.Collections.Generic;

namespace PotatoPlace.Services
{
    /// <summary>
    /// Интерфейс сервиса
    /// </summary>
    public interface IPotatoService
    {
        void Add(Potato potato);

        void Delete(int id);

        void Refresh(Potato p);

        IEnumerable<Potato> GetList();

        Potato GetPotato(int id);
    }
}
