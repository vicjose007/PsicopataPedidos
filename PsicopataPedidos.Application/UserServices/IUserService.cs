using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Application
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User CreateUser(User user);

        User DeleteUser(User userId);


    }
}
