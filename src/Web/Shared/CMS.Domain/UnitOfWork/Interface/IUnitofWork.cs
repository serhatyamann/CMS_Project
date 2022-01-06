using CMS.Domain.Repositories.Interface.EntityType;
using System;
using System.Threading.Tasks;

namespace CMS.Domain.UnitOfWork.Interface
{
    public interface IUnitofWork : IAsyncDisposable
    {
        IAppUserRepository AppUserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IPageRepository PageRepository { get; }
        IProductRepository ProductRepository { get; }
        Task Commit();
        Task ExecuteSqlRaw(string sql, params object[] parameters);
    }
}
