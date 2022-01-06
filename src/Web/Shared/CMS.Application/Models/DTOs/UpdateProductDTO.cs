using CMS.Application.Extensions;
using CMS.Application.Models.VMs;
using CMS.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Application.Models.DTOs
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get => "/images/products/default.jpg"; }

        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;

        [NotMapped]
        [FileExtension]
        public IFormFile Image { get; set; }

        public int CategoryId { get; set; }

        public List<GetCategoryVM> Categories { get; set; }
    }
}
