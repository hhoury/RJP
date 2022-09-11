using Moq;
using RJP.Application.Contracts.Persistence;
using RJP.Domain;
using System;
using System.Collections.Generic;

namespace RJP.Application.UnitTests.Mocks
{
    public class MockTransactionRepository
    {

        public static Mock<ITransactionRepository> GetTransactionRepository()
        {
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                   Id = 1,
                   AccountId = 1,
                   TransactionAmount = 10,
                },
                 new Transaction
                {
                   Id = 2,
                    AccountId = 2,
                   TransactionAmount = 20,
                }
            };

            var mockRepo = new Mock<ITransactionRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(transactions);

            mockRepo.Setup(r => r.Add(It.IsAny<Transaction>())).ReturnsAsync((Transaction transaction) =>
            {
                transactions.Add(transaction);
                return transaction;
            });

            return mockRepo;
        }
    }
}