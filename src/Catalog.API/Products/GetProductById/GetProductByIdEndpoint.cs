﻿
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById
{

    //public record GetProductByIdRequest();

    public record GetProductByIdResponse(Model.Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id , ISender sender)
                =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                var response=result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            }).WithName("GetProductsId")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products Id")
            .WithDescription("Get Products Id");
        }
    }
}
