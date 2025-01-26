

namespace Catalog.API.Products.GetProducts
{


    public record GetProductQuery(int? PageNumber, int? PageSize = 10) : IQuery<GetProductResult>;

    public record GetProductResult(IEnumerable<Model.Product> Products);
    internal class GetProductQueryHandler (IDocumentSession session): IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {

            
            var products = await session.Query<Model.Product>().ToPagedListAsync(query.PageNumber??1,query.PageSize??10,cancellationToken);

            return new GetProductResult(products);

           
        }
    }
}
