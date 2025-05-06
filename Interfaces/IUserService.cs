using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;

namespace ApiRest.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(User user);
        Task<User> GetUserByIdAsync(int id);
    }
}