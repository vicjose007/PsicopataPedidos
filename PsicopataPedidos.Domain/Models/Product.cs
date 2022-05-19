using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PsicopataPedidos.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }

        //[JsonIgnore]

        //public IEnumerable<ShoppingList> ShoppingLists { get; set; }

        //[JsonIgnore]
        //public IEnumerable<ProductCategory> ProductCategories { get; set; }


    }
}
