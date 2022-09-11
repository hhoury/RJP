using RJP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Domain
{
    public class Transaction : BaseDomainEntity
    {
        public decimal TransactionAmount { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
