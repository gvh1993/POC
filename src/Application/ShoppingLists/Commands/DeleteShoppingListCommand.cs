using MediatR;

namespace Application.ShoppingLists.Commands;

public record DeleteShoppingListCommand(Guid Id) : IRequest;

public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommand>
{
    public async Task Handle(DeleteShoppingListCommand request, CancellationToken cancellationToken)
    {
        // TODO: Delete shoppingList in database

        return;
    }
}
