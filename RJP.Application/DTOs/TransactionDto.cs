using RJP.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.DTOs
{
    public class TransactionDto : BaseDto
    {
        public decimal TransactionAmount { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
    }
}
