using Domain.Abstractions;

namespace Domain.Entities;

public class ShoppingListItem : Entity
{
    public string Name { get; private set; }

    public ShoppingListItem(Guid id, string name) : base(id)
    {
        Name = name;
    }
}
