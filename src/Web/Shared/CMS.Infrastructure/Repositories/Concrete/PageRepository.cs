using CMS.Domain.Entities.Concrete;
using CMS.Domain.Repositories.Interface.EntityType;
using CMS.Infrastructure.Context;
using CMS.Infrastructure.Repositories.Abstract;

namespace CMS.Infrastructure.Repositories.Concrete
{
    public class PageRepository : BaseRepository<Page>, IPageRepository
    {
        public PageRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
