using System;
using CMS.Domain.Enums;
namespace CMS.Domain.Entities.Interface
{
    public interface IBaseEntity
    {
        DateTime CreateDate { get; }
        DateTime? UpdateDate { get; }
        DateTime? DeleteDate { get; }
        Status Status { get; }
    }
}
