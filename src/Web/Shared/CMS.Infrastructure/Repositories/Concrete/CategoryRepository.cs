using CMS.Domain.Entities.Concrete;
using CMS.Domain.Repositories.Interface.EntityType;
using CMS.Infrastructure.Context;
using CMS.Infrastructure.Repositories.Abstract;

namespace CMS.Infrastructure.Repositories.Concrete
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
