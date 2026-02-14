using AspireTestCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AspireTest.ApiService.Controllers;

public static class FDTEndpoints
{
    public static void MapFDTEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/FDT").WithTags(nameof(FDT));

        group.MapGet("/", () =>
        {
            return new [] { new FDT() };
        })
        .WithName("GetAllFDTs");

        group.MapGet("/{id}", (int id) =>
        {
            //return new FDT { ID = id };
        })
        .WithName("GetFDTById");

        group.MapPut("/{id}", (int id, FDT input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateFDT");

        group.MapPost("/", (FDT model) =>
        {
            //return TypedResults.Created($"/api/FDTs/{model.ID}", model);
        })
        .WithName("CreateFDT");

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new FDT { ID = id });
        })
        .WithName("DeleteFDT");
    }
}
