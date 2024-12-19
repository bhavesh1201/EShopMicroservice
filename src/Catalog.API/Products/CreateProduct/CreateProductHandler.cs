
namespace Catalog.API.Product.CreateProduct
{


    public record CreateProductCommand(string Name, string Discription , List<string> Category,string ImageFile , decimal Price):ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _session;
        public CreateProductCommandHandler(IDocumentSession session)
        {
            _session=  session;
        }
       public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            //Create Project entity
            //Save result in database
            //return result
            var product = new Model.Product
            {
                Name = command.Name,
                Description=command.Discription,
                Category = command.Category,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            _session.Store(product);
            await _session.SaveChangesAsync();
            return new CreateProductResult(product.Id);
        }
    }
}
