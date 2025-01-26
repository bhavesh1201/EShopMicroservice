
namespace Catalog.API.Products.GetProductById
{

    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;


    public record GetProductByIdResult(Model.Product Product);
    internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        private readonly IDocumentSession _session;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;
        public GetProductByIdQueryHandler(IDocumentSession session,ILogger <GetProductByIdQueryHandler> logger) {


            _session= session;
            _logger= logger;
        }
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {

            _logger.LogInformation("GetProductById is called with query {@Query}",query);
            var result = await _session.LoadAsync<Model.Product>(query.Id,cancellationToken);

            if(result is null)
            {
                throw new ProductNotFoundException(query.Id);
            }

            return new GetProductByIdResult(result);

             


        }
    }
}
