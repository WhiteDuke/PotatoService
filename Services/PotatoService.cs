using Microsoft.EntityFrameworkCore;
using PotatoPlace.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PotatoPlace.Services
{
    public class PotatoService : IPotatoService
    {
        private static int _index = 0;

        private readonly Dictionary<int, Potato> _storage = new Dictionary<int, Potato>();

        private readonly Dictionary<int, string> _types = new Dictionary<int, string>
        {
            [0] = "simple",
            [1] = "complicated",
            [2] = "overhelmed"
        };

        private readonly PotatoContext _context;

        public PotatoService(PotatoContext context = null)
        {
            _context = context;

            if (_context == null)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Potato p = new Potato
                    {
                        Code = $"P{i}",
                        Name = Guid.NewGuid().ToString(),
                        CreateDate = DateTime.Now,
                        TypeId = i % _types.Count,
                        TypeName = _types[i % _types.Count]
                    };

                    AddToStorage(p);
                }
            }
            else
            {
                _context.Types.AddRange(new Models.Type { Name = _types[0] }, new Models.Type { Name = _types[1] }, new Models.Type { Name = _types[2] });
                _context.SaveChanges();

                if (!_context.Potatoes.AnyAsync().Result)
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Potato p = new Potato
                        {
                            Code = $"P{i}",
                            Name = Guid.NewGuid().ToString(),
                            CreateDate = DateTime.Now,
                        };

                        p.Type = _context.Types.Find(i % _types.Count);
                        _context.Potatoes.Add(p);
                    }
                }

                _context.SaveChanges();
            }
        }

        public void Add(Potato potato)
        {
            if (_context == null)
                AddToStorage(potato);
            else
                AddToDb(potato);
        }

        private void AddToStorage(Potato potato)
        {
            if (potato.IsNew() || !_storage.ContainsKey(potato.Id))
            {
                potato.Id = _index;
                _index++;
                _storage.Add(potato.Id, potato);
                _storage[potato.Id].CreateDate = DateTime.Now;
            }
            else throw new ArgumentException($"Попытка повторного добавления данных по ключу {potato.Id}");
        }

        private void AddToDb(Potato potato)
        {
            potato.Id = 0;
            if (potato.TypeId == 0)
                potato.TypeId = null;

            _context.Potatoes.Add(potato);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (_context == null)
                DeleteFromStorage(id);
            else
                DeleteFromDb(id);
        }

        private void DeleteFromStorage(int id)
        {
            if (_storage.ContainsKey(id))
                _storage.Remove(id);
            else throw new ArgumentOutOfRangeException($"Не найден экземпляр данных с идентификатором {id}");
        }

        private void DeleteFromDb(int id)
        {
            Potato potato = new Potato { Id = id };
            _context.Entry(potato).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(int id, Potato p)
        {
            if (_context == null)
                UpdateInStorage(id, p);
            else
                UpdateInDb(id, p);
        }

        private void UpdateInStorage(int id, Potato p)
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

        private void UpdateInDb(int id, Potato potato)
        {
            Potato p =  _context.Potatoes.Find(id);
            if (p != null)
            {
                if (!string.IsNullOrEmpty(potato.Code))
                    p.Code = potato.Code;

                if (!string.IsNullOrEmpty(potato.Name))
                    p.Name = potato.Name;

                p.UpdateDate = DateTime.Now;
                _context.Potatoes.Update(p);

                _context.SaveChanges();
            }
        }

        public IEnumerable<Potato> GetList()
        {
            return _context == null ? GetListFromStorage() : GetListFromDb();
        }

        private IEnumerable<Potato> GetListFromStorage()
        {
            foreach (Potato potato in _storage.Values)
                yield return potato;
        }

        private IEnumerable<Potato> GetListFromDb()
        {
            foreach (Potato p in _context.Potatoes)
                yield return p;
        }

        public Potato GetPotato(int id)
        {
            return _context == null ? GetPotatoFromStorage(id) : GetPotatoFromDb(id);
        }

        private Potato GetPotatoFromStorage(int id)
        {
            return _storage.ContainsKey(id) ? _storage[id] : throw new KeyNotFoundException($"Отсутствуют данные по идентификатору {id}");
        }

        private Potato GetPotatoFromDb(int id)
        {
            Task<Potato> potato = _context.Potatoes.FirstOrDefaultAsync(p => p.Id == id);

            return potato.Result ?? throw new KeyNotFoundException($"Отсутствуют данные по идентификатору {id}");
        }
    }
}