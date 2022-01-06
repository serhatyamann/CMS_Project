using CMS.Domain.Repositories.Interface.EntityType;
using CMS.Domain.UnitOfWork.Interface;
using CMS.Infrastructure.Context;
using CMS.Infrastructure.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CMS.Infrastructure.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext _db;

        public UnitofWork(AppDbContext appDbContext)
        {
            _db = appDbContext ?? throw new ArgumentNullException("Db connection failed.");
        }

        private IAppUserRepository _appUserRepository;
        public IAppUserRepository AppUserRepository
        {
            get
            {
                if (_appUserRepository == null)
                {
                    _appUserRepository = new AppUserRepository(_db);
                }

                return _appUserRepository;
            }
        }
        private ICategoryRepository _categoryRepository;

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_db);
                }

                return _categoryRepository;
            }
        }

        private IPageRepository _pageRepository;
        public IPageRepository PageRepository
        {
            get
            {
                if (_pageRepository == null)
                {
                    _pageRepository = new PageRepository(_db);
                }

                return _pageRepository;
            }
        }

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }

                return _productRepository;
            }
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }

        private bool isDisposed = false;

        public async ValueTask DisposeAsync()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);
            }
        }

        protected async Task DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _db.DisposeAsync();
            }
        }

        public async Task ExecuteSqlRaw(string sql, params object[] parameters)
        {
            await _db.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
