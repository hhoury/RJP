using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RJP.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
