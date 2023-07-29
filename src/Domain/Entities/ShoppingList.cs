using Domain.Abstractions;

namespace Domain.Entities;

public class ShoppingList : Entity
{
    private readonly List<ShoppingListItem> _shoppingItems = new();

    public string Name { get; private set; }
    public IReadOnlyCollection<ShoppingListItem> ShoppingItems => _shoppingItems;

    public ShoppingList(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public void AddItem(ShoppingListItem item)
    {
        _shoppingItems.Add(item);
    }
}
