using RJP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Domain
{
    public class Account : BaseDomainEntity
    {
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
