using CMS.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Application.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only letters are allowed")]
        public string Name { get; set; }

        public string Slug => Name.ToLower().Replace(" ", "_");
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
