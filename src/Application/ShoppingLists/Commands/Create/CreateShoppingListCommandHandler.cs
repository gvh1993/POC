using MediatR;

namespace Application.ShoppingLists.Commands.Create;

public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommand>
{
    public async Task Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
    {
        // TODO: create shoppingList in database

        return;
    }
}
