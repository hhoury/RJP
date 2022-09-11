using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RJP.Application.DTOs
{
    public class CreateAccountDto
    {
        [Column(TypeName = "decimal(14, 2)")]
        public decimal Balance { get; set; } = 0;

        public int CustomerId { get; set; }
    }
}
