using AspireTestCore.Interfaces;
using AspireTestCore.Models;
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

       group.MapGet("/statistiques/{id}", async (IFDTService fDTService,int id) =>
        {
            return await fDTService.GetStatistiquesEmployeDtosAsync(id);
        })
        .WithName("GetStatistiquesById");
    }
}
