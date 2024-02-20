using Microsoft.EntityFrameworkCore;
using TestDDD.Data.Exceptions;

namespace TestDDD.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected AppDbContext Context;
        protected DbSet<T> DbSet;
        protected readonly ILogger Logger;

        public Repository(
            AppDbContext context,
            ILogger logger)
        {
            Context = context;
            Logger = logger;
            DbSet = Context.Set<T>();
        }
        public virtual async Task<T> CreateAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                var createdEntity = (await DbSet.AddAsync(entity)).Entity;
                return createdEntity;
            }
            catch(Exception ex)
            {
                Logger.LogWarning(exception:ex, message:"Error adding entity");
                throw new Exception("Error adding entity");
            }
        }

        public virtual async Task<T> GetAsync(int id)
        {
            try
            {
                return await Context.FindAsync<T>(id) ?? throw new EntityNotFoundException();
            }
            catch (EntityNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Logger.LogWarning(exception: ex, message: "Error getting entity with id {Id}", id);
                throw new Exception("Error getting entity");
            }
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await DbSet.FindAsync(id);
                if (entity == null)
                {
                    Logger.LogWarning("Entity with id {Id} not found",id);
                    return false;
                }

                DbSet.Remove(entity);
                return true;
            }
            catch
            {
                Logger.LogWarning("Error deleting entity with id {Id}", id);
                return false;
            }
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}
