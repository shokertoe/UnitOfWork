namespace TestDDD.Data
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> AllAsync();
    }
}
