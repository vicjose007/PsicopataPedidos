using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Application
{
    public interface IShoppingListService
    {
        List<ShoppingList> GetShoppingList();

        ShoppingList CreateShoppingList(ShoppingList shoppingList);

        ShoppingList DeleteShoppingList(ShoppingList shoppingList);
    }
}
