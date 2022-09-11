using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RJP.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RJP.Application.DTOs
{
    public class TransactionDto : BaseDto
    {
        [Column(TypeName = "decimal(14, 2)")]

        public decimal TransactionAmount { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
    }
}
