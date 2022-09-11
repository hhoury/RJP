using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
