using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        //Foreing Key
        public int UserId { get; set; }
        public User? User { get; set; }

        public double Total { get; set; }
    }
}
