﻿
namespace AccountService.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
    }
}
