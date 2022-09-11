using Moq;
using RJP.Application.Contracts.Persistence;
using RJP.Domain;
using System;
using System.Collections.Generic;

namespace RJP.Application.UnitTests.Mocks
{
    public static class MockAccountRepository
    {

        public static Mock<IAccountRepository> GetAccountRepository()
        {
            var accounts = new List<Account>
            {
                new Account
                {
                   Id = 1,
                   Balance= 0,
                   CustomerId= 1
                },
                 new Account
                {
                   Id = 1,
                   Balance= 300,
                   CustomerId= 2
                }
            };

            var mockRepo = new Mock<IAccountRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(accounts);

            mockRepo.Setup(r => r.Add(It.IsAny<Account>())).ReturnsAsync((Account account) =>
            {
                accounts.Add(account);
                return account;
            });

            return mockRepo;
        }
    }
}