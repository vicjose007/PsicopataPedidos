using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Application.Dtos
{
    public class UserDto : User
    {

        public string? Name { get; set; }

        public string? Password { get; set; }
    }
}
