using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Domain.Models
{
    public class User
    {
        public int Id { get; set; } 

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime Created { get; set; }

        public bool IsAdmin { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; } 

        public IEnumerable<Order>? Orders { get; set; }

        public IEnumerable<ShoppingList>? ShoppingLists { get; set; }

    }
}
