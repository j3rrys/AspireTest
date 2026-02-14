using AspireTestCore.Models;
using AspireTestInfra.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AspireTest.ApiService.Controllers;

public static class FDTEndpoints
{
    public static void MapFDTEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/FDT").WithTags(nameof(FDT));

        group.MapGet("/", async (IFDTService fDTService) =>
        {
            return await fDTService.GetAllFDTAsync();
        })
        .WithName("GetAllFDTs");

        group.MapGet("/{id}", async (IFDTService fDTService,int id) =>
        {
            return await fDTService.GetEmployeFDtAsync(id);
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
