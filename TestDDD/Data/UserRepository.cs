


namespace TestDDD.Data
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
