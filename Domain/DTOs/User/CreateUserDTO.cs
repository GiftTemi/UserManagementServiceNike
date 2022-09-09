using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public class CreateUserDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public DateTime DOB { get; set; }

        public string? EmailAddress { get; set; }
    }
}
