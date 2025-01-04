
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductByCategory
{

    public record GetProductByCategoryRequest();
    public record GetProductByCategoryResponse(IEnumerable<Model.Product> Products);


    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapGet("/products/category/{category}", async (string category , ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);

            }).WithName("GetProductsbycategory")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products  by category")
            .WithDescription("Get Products by category");
           
        }
    }
}
