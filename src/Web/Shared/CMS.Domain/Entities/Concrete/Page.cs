using CMS.Domain.Entities.Interface;
using CMS.Domain.Enums;
using System;

namespace CMS.Domain.Entities.Concrete
{
    public class Page:IBaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}
