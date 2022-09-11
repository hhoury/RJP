using RJP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Domain
{
    public class Customer : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
