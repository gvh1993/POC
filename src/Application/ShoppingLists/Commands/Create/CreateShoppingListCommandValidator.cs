using FluentValidation;

namespace Application.ShoppingLists.Commands.Create;

public sealed class CreateShoppingListCommandValidator : AbstractValidator<CreateShoppingListCommand>
{
    public CreateShoppingListCommandValidator()
    {
        RuleFor(x => x.shoppingList.Name)
            .NotEmpty()
            .WithErrorCode("400")
            .WithMessage("ShoppingListName should not be empty.");
    }
}
