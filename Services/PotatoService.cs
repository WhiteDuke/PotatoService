using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotatoPlace.Services
{
    public class PotatoService : IPotatoService
    {
        private Dictionary<int, Potato> _storage = new Dictionary<int, Potato>();

        public void Add(Potato potato)
        {
            if (!_storage.ContainsKey(potato.Id))
                _storage.Add(potato.Id, potato);
        }

        public void Delete(int id)
        {
            if (_storage.ContainsKey(id))
                _storage.Remove(id);
        }

        public void Refresh(Potato p)
        {
            if (_storage.ContainsKey(p.Id))
            {
                _storage[p.Id] = p;
            }
        }

        public IEnumerable<Potato> GetList()
        {
            foreach (Potato potato in _storage.Values)
                yield return potato;
        }

        public Potato GetPotato(int id)
        {
            if (_storage.ContainsKey(id))
                return _storage[id];

            return null;
        }
    }
}