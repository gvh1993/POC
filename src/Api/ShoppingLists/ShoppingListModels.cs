namespace Api.ShoppingLists;

public record CreateShoppingList(string Name);
public record ShoppingList(Guid Id, string Name);
