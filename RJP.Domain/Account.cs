using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RJP.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RJP.Domain
{
    public class Account : BaseDomainEntity
    {
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
