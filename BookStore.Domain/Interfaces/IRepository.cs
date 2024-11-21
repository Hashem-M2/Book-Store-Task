

public interface IRepository
{
    IQueryable<T> GetAll<T>(string sql, params object[] parameters) where T : class;

    Task<int> CreateAsync(string sql, params object[] parameters);

    Task<int> Update(string sql, params object[] parameters);

    Task<int> Delete(string sql, params object[] parameters);
}
