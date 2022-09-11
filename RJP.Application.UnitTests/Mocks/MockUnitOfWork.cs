using Moq;
using RJP.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockCustomerRepo = MockCustomerRepository.GetCustomerRepository();
            var mockAccountRepo = MockAccountRepository.GetAccountRepository();
            var mockTtansactionRepo = MockTransactionRepository.GetTransactionRepository();


            mockUow.Setup(r => r.CustomerRepository).Returns(mockCustomerRepo.Object);
            mockUow.Setup(r => r.AccountRepository).Returns(mockAccountRepo.Object);
            mockUow.Setup(r => r.TransactionRepository).Returns(mockTtansactionRepo.Object);

            return mockUow;
        }
    }
}
