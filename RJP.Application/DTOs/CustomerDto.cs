using RJP.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.DTOs
{
    public class CustomerDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
