namespace Catalog.API.Products.GetProducts
{


    public record GetProductQuery() : IQuery<GetProductResult>;

    public record GetProductResult(IEnumerable<Model.Product> Products);
    internal class GetProductQueryHandler (IDocumentSession session , ILogger<GetProductQueryHandler> logger): IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {

            logger.LogInformation("GetProductHandler.Handle called with {@Query}",query);
            var products = await session.Query<Model.Product>().ToListAsync(cancellationToken);

            return new GetProductResult(products);

           
        }
    }
}
