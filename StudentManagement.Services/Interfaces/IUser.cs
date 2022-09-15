using StudentManagement.Models.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services.Interfaces
{
    public interface IUser
    {
        Task<UserDto> Register(UserDto request);
        Task<string> Login(UserDto request);
    }
}

