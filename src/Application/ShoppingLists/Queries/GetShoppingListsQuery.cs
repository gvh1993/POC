
using Domain.Entities;
using MediatR;

namespace Application.ShoppingLists.Queries;

public sealed record GetShoppingListsQuery() : IRequest<IEnumerable<ShoppingList>>;

public class GetShoppingListsQueryHandler : IRequestHandler<GetShoppingListsQuery, IEnumerable<ShoppingList>>
{
    async Task<IEnumerable<ShoppingList>> IRequestHandler<GetShoppingListsQuery, IEnumerable<ShoppingList>>.Handle(GetShoppingListsQuery request, CancellationToken cancellationToken)
    {
        var shoppingList = new ShoppingList(Guid.NewGuid(), "Boodschappenlijst 1");
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Brood"));
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Melk"));
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Eieren"));
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Shampoo"));

        return new[] { shoppingList };
    }
}
