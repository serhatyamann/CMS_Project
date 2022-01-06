using CMS.Application.Models.DTOs;
using CMS.Application.Models.VMs;
using CMS.Domain.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Application.Services.Interface
{
    public interface IPageService
    {
        Task Create(CreatePageDTO model);
        Task Update(UpdatePageDTO model);
        Task Delete(int id);

        Task<UpdatePageDTO> GetById(int id);
        Task<List<GetPageVM>> GetPages();

        Task<bool> isPageExists(string slug);

        Task<Page> GetBySlug(string slug);
    }
}
