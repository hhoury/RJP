using Moq;
using RJP.Application.Contracts.Persistence;
using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.UnitTests.Mocks
{
    public static class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                   Id = 1,
                   Name = "test",
                   Surname="sur test"
                },
                 new Customer
                {
                   Id = 2,
                   Name = "test new",
                   Surname="sur test new"
                }
            };

            var mockRepo = new Mock<ICustomerRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(customers);

            mockRepo.Setup(r => r.Add(It.IsAny<Customer>())).ReturnsAsync((Customer customer) =>
            {
                customers.Add(customer);
                return customer;
            });

            return mockRepo;

        }
    }
}
