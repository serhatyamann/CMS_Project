using CMS.Application.Models.DTOs;
using CMS.Application.Models.VMs;
using CMS.Domain.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task Create(CreateCategoryDTO model);
        Task Update(UpdateCategoryDTO model);
        Task Delete(int id);

        Task<UpdateCategoryDTO> GetById(int id);
        Task<List<GetCategoryVM>> GetCategories();

        Task<Category> GetBySlug(string slug);
        Task<Category> GetCategoryById(int id);
    }
}
