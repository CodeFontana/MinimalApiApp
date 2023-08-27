using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace MinimalApi.Endpoints;

public static class PersonApi
{
    public static void AddPersonApiEndpoints(this WebApplication app)
    {
        app.MapGet("/People", ReadAll);
        app.MapGet("/Person/{id}", Read);
        app.MapPost("/Person", Create);
        app.MapPut("/Person", Update);
        app.MapDelete("/Person/{id}", Delete);
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
            return Results.Problem(e.Message, statusCode: 500);
        }
    }

    private static async Task<IResult> ReadAsync(IPersonRepository db, int id)
    {
        try
        {
            PersonModel? result = await db.ReadAsync(id);

            if (result is null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message, statusCode: 500);
        }
    }

    private static async Task<IResult> CreateAsync(IPersonRepository db, PersonModel person)
    {
        try
        {
            int result = await db.Create(person);
            return Results.Ok(result);
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message, statusCode: 500);
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
            return Results.Problem(e.Message, statusCode: 500);
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
            return Results.Problem(e.Message, statusCode: 500);
        }
    }
}
