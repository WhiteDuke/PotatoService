using System;
using System.Collections.Generic;

namespace PotatoPlace.Services
{
    public class PotatoService : IPotatoService
    {
        private Dictionary<int, Potato> _storage = new Dictionary<int, Potato>();

        public PotatoService()
        {
            for (int i = 1; i <= 5; i++)
            {
                Potato p = new Potato
                {
                    Id = i,
                    Code = $"P{i}",
                    Name = Guid.NewGuid().ToString(),
                    CreateDate = DateTime.Now,
                    TypeId = i,
                    TypeName = "simple"
                };

                p.UpdateDate = p.CreateDate;

                Add(p);
            }
        }

        public void Add(Potato potato)
        {
            if (!_storage.ContainsKey(potato.Id))
                _storage.Add(potato.Id, potato);
            else throw new ArgumentException($"Попытка повторного добавления данных по ключу {potato.Id}");
        }

        public void Delete(int id)
        {
            if (_storage.ContainsKey(id))
                _storage.Remove(id);
            else throw new ArgumentOutOfRangeException($"Не найден экземпляр данных с идентификатором {id}");
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