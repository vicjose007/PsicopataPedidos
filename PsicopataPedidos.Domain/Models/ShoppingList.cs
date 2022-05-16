using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Domain.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }


        //Foreing Key User
        public int UserId { get; set; }
        public User? User { get; set; }
       
        //Foreing Key Product
        public int ProductId { get; set; }
        public Product? Product { get; set; }


        public int Count { get; set; }
        public DateTime Date { get; set; }

    }
}
