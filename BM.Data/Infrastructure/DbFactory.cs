namespace BM.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        BirthdaysEntities dbContext;

        public BirthdaysEntities Init()
        {
            return dbContext ?? (dbContext = new BirthdaysEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
