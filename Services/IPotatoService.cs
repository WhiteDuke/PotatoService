using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotatoService.Services
{
    /// <summary>
    /// Интерфейс сервиса
    /// </summary>
    interface IPotatoService
    {
        void Add(Potato potato);

        void Delete(int id);

        void Refresh();
    }
}
