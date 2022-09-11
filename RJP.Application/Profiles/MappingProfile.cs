using AutoMapper;
using RJP.Application.DTOs;
using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();

            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, CreateAccountDto>().ReverseMap();

            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<Transaction, CreateTransactionDto>().ReverseMap();
        }
    }
}
