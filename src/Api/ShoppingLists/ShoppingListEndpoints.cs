using Api.ShoppingLists;
using Application.ShoppingLists.Queries;
using Application.ShoppingLists.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace API.ShoppingLists;

public static class ShoppingListEndpoints
{
    public static void AddShoppingListEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/shoppingList", async ([FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetShoppingListsQuery());

            return Results.Ok(result);
        });

        app.MapGet("/shoppingList/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] ISender sender) =>
        {
            var result = await sender.Send(new GetShoppingListQuery(id));

            return Results.Ok(result);
        });

        app.MapPatch("/shoppingList", async (
            [FromBody] ShoppingList shoppingList,
            [FromServices] ISender sender) =>
        {
            var internalShoppingList = new Domain.Entities.ShoppingList(shoppingList.Id, shoppingList.Name);

            await sender.Send(new UpdateShoppingListCommand(internalShoppingList));

            return Results.Ok(shoppingList);
        });

        app.MapPut("/shoppingList", async (
            [FromServices] ISender sender,
            [FromServices] IValidator<CreateShoppingListCommand> validator,
            [FromBody] CreateShoppingList shoppingList) =>
        {

            var internalShoppingList = new Domain.Entities.ShoppingList(Guid.NewGuid(), shoppingList.Name);
            var command = new CreateShoppingListCommand(internalShoppingList);

            var result = await validator.ValidateAsync(command);
            if (!result.IsValid)
            {
                return Results.ValidationProblem(result.ToDictionary());
            }

            await sender.Send(command);

            return Results.Ok(internalShoppingList.Id);
        })
        .Produces(StatusCodes.Status200OK);

        app.MapDelete("/shoppingList/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] ISender sender
            ) =>
        {
            await sender.Send(new DeleteShoppingListCommand(id));

            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent);
    }
}
