using PsicopataPedidos.Application;
using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Infrastructure
{
    public class ShoppingListRepository : IShoppingListRepository
    {

        public static List<ShoppingList> shoppingLists = new List<ShoppingList>()
        {

        };

        private readonly ProductDbContext _shoppingListDbContext;
        public ShoppingListRepository(ProductDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public ShoppingList CreateShoppingList(ShoppingList shoppingList)
        {
            _shoppingListDbContext.ShoppingList.Add(shoppingList);
            _shoppingListDbContext.SaveChanges();
            return shoppingList;
        }

        public ShoppingList DeleteShoppingList(ShoppingList shoppingList)
        {
            _shoppingListDbContext.ShoppingList.Remove(shoppingList);
            _shoppingListDbContext.SaveChanges();

            return null;
        }

        public List<ShoppingList> GetShoppingList()
        {
            return _shoppingListDbContext.ShoppingList.ToList();
        }
    }
}
