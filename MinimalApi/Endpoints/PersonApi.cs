using DataAccessLibrary.Models;
using DataAccessLibrary.Repository;

namespace MinimalApi.Endpoints;

public static class PersonApi
{
    public static void AddPersonApiEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/People", ReadAllAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireRateLimiting("fixed");

        app.MapGet("/api/v1/Person/{id:int}", ReadAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireRateLimiting("fixed");

        app.MapPost("/api/v1/Person", CreateAsync)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireRateLimiting("fixed");

        app.MapPut("/api/v1/Person", UpdateAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireRateLimiting("fixed");

        app.MapDelete("/api/v1/Person/{id:int}", DeleteAsync)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError)
            .RequireRateLimiting("fixed");
    }

    private static async Task<IResult> ReadAllAsync(IPersonRepository db)
    {
        try
        {
            IEnumerable<PersonModel> result = await db.ReadAllAsync();
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            return Results.Problem(
                type: "Internal Server Error",
                title: "An error occurred while reading all people",
                detail: e.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> ReadAsync(IPersonRepository db, int id)
    {
        try
        {
            PersonModel? result = await db.ReadAsync(id);

            return result is null
                ? Results.NotFound()
                : Results.Ok(result);
        }
        catch (Exception e)
        {
            return Results.Problem(
                type: "Internal Server Error",
                title: "An error occurred while reading a person",
                detail: e.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> CreateAsync(IPersonRepository db, PersonModel person)
    {
        try
        {
            int result = await db.Create(person);
            return Results.Created($"/api/v1/Person/{result}", result);
        }
        catch (Exception e)
        {
            return Results.Problem(
                type: "Internal Server Error",
                title: "An error occurred while creating a new person",
                detail: e.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> UpdateAsync(IPersonRepository db, PersonModel person)
    {
        try
        {
            await db.UpdateAsync(person);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(
                type: "Internal Server Error",
                title: "An error occurred while updating a person",
                detail: e.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    private static async Task<IResult> DeleteAsync(IPersonRepository db, int id)
    {
        try
        {
            await db.DeleteAsync(id);
            return Results.Ok();
        }
        catch (Exception e)
        {
            return Results.Problem(
                type: "Internal Server Error",
                title: "An error occurred while deleting a person",
                detail: e.Message,
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }
}
