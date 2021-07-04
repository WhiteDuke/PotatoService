using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotatoService.Services
{
    public class PotatoService : IPotatoService
    {
        public void Add(Potato potato)
        {
            Log.Information("Adding potato");
        }

        public void Delete(int id)
        {
            Log.Information("Deleting potato");
        }

        public void Refresh()
        {
            Log.Information("Refreshing list");
        }
    }
}
