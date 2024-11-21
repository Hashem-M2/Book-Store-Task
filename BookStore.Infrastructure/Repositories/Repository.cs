

using BookStore.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository: IRepository
    {
        private readonly BookStoreContext _context;
        public Repository(BookStoreContext context)
        {
            _context = context;
       }

        public async Task<int> CreateAsync(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }


        public async Task<int> Update(string sql, params object[] parameters)
        {
            var result = await _context.Database.ExecuteSqlRawAsync(sql, parameters); 
            return result;
        }

        public async Task<int> Delete(string sql, params object[] parameters)
        {
            
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public IQueryable<T> GetAll<T>(string sql, params object[] parameters) where T : class
        {
            return _context.Set<T>().FromSqlRaw(sql, parameters);
        }
    }
}
