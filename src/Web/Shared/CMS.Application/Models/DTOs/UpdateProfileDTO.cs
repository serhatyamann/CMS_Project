using CMS.Application.Extensions;
using CMS.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Application.Models.DTOs
{
    public class UpdateProfileDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ImagePath { get => "/images/users/default.jpg"; }

        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;

        [NotMapped]
        [FileExtension]
        public IFormFile Image { get; set; }
    }
}
