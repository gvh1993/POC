using MediatR;
using Domain.Entities;

namespace Application.ShoppingLists.Commands;

public record CreateShoppingListCommand(ShoppingList shoppingList) : IRequest;
