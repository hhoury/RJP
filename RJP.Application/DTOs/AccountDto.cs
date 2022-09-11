using RJP.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.DTOs
{
    public class AccountDto : BaseDto
    {
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public CustomerDto Customer{ get; set; } 
    }
}
