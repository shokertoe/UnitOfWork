namespace TestDDD.Data
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        Task CompleteAsync();
    }
}
