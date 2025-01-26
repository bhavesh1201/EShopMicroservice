
namespace Catalog.API.Products.GetProductById
{

    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;


    public record GetProductByIdResult(Model.Product Product);
    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        private readonly IDocumentSession _session;
        
        public GetProductByIdQueryHandler(IDocumentSession session  ) {


            _session= session;
            
        }
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {


            var result = await _session.LoadAsync<Model.Product>(query.Id,cancellationToken);

            if(result is null)
            {
                throw new ProductNotFoundException(query.Id);
            }

            return new GetProductByIdResult(result);

             


        }
    }
}
