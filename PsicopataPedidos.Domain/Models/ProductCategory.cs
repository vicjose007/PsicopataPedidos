using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Domain.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        //Foreing Key Product
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public string? Category { get; set; }
    }
}
