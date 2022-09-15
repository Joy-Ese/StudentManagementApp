using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DataObjects
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserDto
    {
        public string RegNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}



