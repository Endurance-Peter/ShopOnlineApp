using ShopOnline.Api.Contracts;

namespace ShopOnline.Api.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository ProductRepository { get; set; }
        Task CommitAsync();
    }
}
