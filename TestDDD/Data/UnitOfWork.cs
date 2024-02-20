namespace TestDDD.Data
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;
        public IRepository<User> Users { get; private set; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _appDbContext = context;
            _logger = loggerFactory.CreateLogger("logs");
            Users = new UserRepository(context, _logger);
        }

        public Task CompleteAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.DisposeAsync();
        }
    }
}
