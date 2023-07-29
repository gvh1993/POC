
using Domain.Entities;
using MediatR;

namespace Application.ShoppingLists.Queries;

public sealed record GetShoppingListQuery(Guid Id) : IRequest<ShoppingList>;

public class GetShoppingListQueryHandler : IRequestHandler<GetShoppingListQuery, ShoppingList>
{
    async Task<ShoppingList> IRequestHandler<GetShoppingListQuery, ShoppingList>.Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
    {
        var shoppingList = new ShoppingList(request.Id, "Boodschappenlijst 1");
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Brood"));
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Melk"));
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Eieren"));
        shoppingList.AddItem(new ShoppingListItem(Guid.NewGuid(), "Shampoo"));

        return shoppingList;
    }
}
