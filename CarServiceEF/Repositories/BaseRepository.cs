using CarServiceBL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceEF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
      
            private AppDbContext _db;
            public BaseRepository(AppDbContext db)
            {
                _db = db;
            }

            public void Add(T model)
            {
                _db.Add(model);
                SaveData();
            }


        public void Delete(int id)
        {
            var delete = _db.Set<T>().Find(id);
            if (delete != null)
            {
                _db.Set<T>().Remove(delete);
            }
            SaveData();
        }

        public IEnumerable<T> GetAll()
            {
                return _db.Set<T>().ToList();
            }

            public async Task<IEnumerable<T>> GetAllAsync()
            {
                return await _db.Set<T>().ToListAsync();

            }

            public T GetById(int id)
            {
                return _db.Set<T>().Find(id)!;
            }

            public async Task<T> GetByIdAsync(int id)
            {

                var result = await _db.Set<T>().FindAsync(id)!;
                return result;

            }

            public void SaveData()
            {
                _db.SaveChanges();
            }
            public void UPdate(int id, T model)
            {
                _db.Set<T>().Update(model);
                SaveData();

            }
       
        }
}
