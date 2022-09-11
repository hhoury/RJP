namespace TransactionService.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal TransactionAmount { get; set; }
        public int AccountId { get; set; }
    }
}
