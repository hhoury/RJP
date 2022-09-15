using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RJP.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RJP.Domain
{
    public class Transaction : BaseDomainEntity
    {
        [Column(TypeName = "decimal(14, 2)")]
        public decimal TransactionAmount { get; set; }

        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
