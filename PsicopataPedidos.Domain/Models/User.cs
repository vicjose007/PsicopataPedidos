using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PsicopataPedidos.Domain.Models
{
    public class User
    {
        public int Id { get; set; } 

        public string? Name { get; set; }
        [JsonIgnore]
        public string? Email { get; set; }

        public string? Password { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; }
        [JsonIgnore]
        public bool IsAdmin { get; set; }
        [JsonIgnore]
        public byte[]? PasswordHash { get; set; } 
        [JsonIgnore]
        public byte[]? PasswordSalt { get; set; } 
        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; }
        [JsonIgnore]
        public IEnumerable<ShoppingList>? ShoppingLists { get; set; }

    }
}
