﻿
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.DeleteProduct
{


   // public record DeleteProductRequest(Guid Id);

    public record DeleteProductResponse(bool isSuccess);
    public class DeleteProductEndpoint : ICarterModule 
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid Id , ISender sender) =>
            {

              var result=   await sender.Send(new DeleteProductCommand(Id));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);

            }).WithName("Delete product")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete product")
            .WithDescription("Delete product");
        }
    }
}
