using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.UsersDto
{
    public class NewUserDto : DtoBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IdBaseCurrency { get; set; }
        public int DayOfSalary { get; set; }
        public decimal Salary { get; set; }
        public IFormFile Picture { get; set; }
        public string ServerThatHosts { get; set; }
    }
}
