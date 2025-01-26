using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCategory
{

    public record GetProductByCategoryQuery(string category):IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Model.Product> Products);
    internal class GetProductByCategoryHandler (IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            

            var products = await session.Query<Model.Product>()
                .Where(p=>p.Category.Contains(query.category))
                .ToListAsync(cancellationToken);

            return new GetProductByCategoryResult(products);

        }
    }
}
