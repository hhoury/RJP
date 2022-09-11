
using System.ComponentModel.DataAnnotations.Schema;

namespace RJP.Application.DTOs
{
    public class CreateTransactionDto
    {
        public int AccountId { get; set; }
        [Column(TypeName = "decimal(14, 2)")]
        public decimal TransactionAmount { get; set; }
    }
}
