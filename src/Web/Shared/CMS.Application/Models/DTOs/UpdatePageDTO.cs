using CMS.Domain.Enums;
using System;

namespace CMS.Application.Models.DTOs
{
    public class UpdatePageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug => Title.ToLower().Replace(" ", "_");

        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
