using System;
using System.Collections.Generic;
using System.Text;
using RJP.Application.DTOs.CreateAccountDto;

namespace RJP.Application.UnitTests.Accounts.Commands
{
    public class CreateAccountCommandTest
    {
		private readonly IMapper _mapper;
		private readonly Mock<IUnitOfWork> _mockUow;
		private readonly CreateAccountDto _createAccountDto;

		public CreateAccountCommandTest()
		{
			_mockUow = MockUnitOfWork.GetUnitOfWork();
		}
	}
}
