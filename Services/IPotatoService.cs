using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
