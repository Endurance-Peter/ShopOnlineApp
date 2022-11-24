using ShopOnline.Api.Contracts;
using ShopOnline.Api.Data;
using ShopOnline.Api.Respositories;

namespace ShopOnline.Api.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopOnlineDbContext context;

        public UnitOfWork(ShopOnlineDbContext context)
        {
            this.context = context;
            ProductRepository = new ProductRepository(context);
        }
        public IProductRepository ProductRepository { get ; set ; }

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("unable a commit to database", ex.InnerException);
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
