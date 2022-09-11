using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RJP.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RJP.Application.DTOs
{
    public class AccountDto : BaseDto
    {
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Balance { get; set; } = 0;

        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
