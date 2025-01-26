
using Catalog.API.Product.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{

    public record UpdateProductRequest(Guid Id, string Name, string Discription, List<string> Category, string ImageFile, decimal Price);

    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await sender.Send(command); 

                var response=result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);

            })
             .WithName("UpdateProduct")
             .Produces<CreateProductResponse>(StatusCodes.Status201Created)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Update Product")
             .WithDescription("Update Product");
        }
    }
}
