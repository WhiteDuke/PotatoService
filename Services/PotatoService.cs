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

                Add(p);
            }
        }

        public void Add(Potato potato)
        {
            if (!_storage.ContainsKey(potato.Id))
            {
                _storage.Add(potato.Id, potato);
                _storage[potato.Id].CreateDate = DateTime.Now;
            }
            else throw new ArgumentException($"Попытка повторного добавления данных по ключу {potato.Id}");
        }

        public void Delete(int id)
        {
            if (_storage.ContainsKey(id))
                _storage.Remove(id);
            else throw new ArgumentOutOfRangeException($"Не найден экземпляр данных с идентификатором {id}");
        }

        public void Update(int id, Potato p)
        {
            if (_storage.ContainsKey(id))
            {
                if (!string.IsNullOrEmpty(p.Code))
                    _storage[id].Code = p.Code;

                if (!string.IsNullOrEmpty(p.Name))
                    _storage[id].Name = p.Name;

                if (!string.IsNullOrEmpty(p.TypeName))
                    _storage[id].TypeName = p.TypeName;

                _storage[id].UpdateDate = DateTime.Now;
            }
            else
                throw new KeyNotFoundException($"Отсутствуют данные по идентификатору {id}");
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

            throw new KeyNotFoundException($"Отсутствуют данные по идентификатору {id}");
        }
    }
}