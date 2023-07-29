using MediatR;
using Domain.Entities;

namespace Application.ShoppingLists.Commands;

public record UpdateShoppingListCommand(ShoppingList shoppingList) : IRequest;

public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommand>
{
    public async Task Handle(UpdateShoppingListCommand request, CancellationToken cancellationToken)
    {
        // TODO: update database

        return;
    }
}
