using PsicopataPedidos.Domain.Models;

namespace PsicopataPedidos.Application
{

    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;


        public ShoppingListService(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public ShoppingList CreateShoppingList(ShoppingList shoppingList)
        {
            _shoppingListRepository.CreateShoppingList(shoppingList);
            return shoppingList;
        }
        public ShoppingList DeleteShoppingList(ShoppingList shoppingList)
        {
            _shoppingListRepository.DeleteShoppingList(shoppingList);
            return shoppingList;
        }

        public List<ShoppingList> GetShoppingList()
        {
            var shoppingLists = _shoppingListRepository.GetShoppingList();

            return shoppingLists;
        }
    }
}



