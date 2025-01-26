

using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.UpdateProduct
{

    public record UpdateProductCommand(Guid Id ,string Name, string Discription, List<string> Category, string ImageFile, decimal Price) :ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool isSuccess);

    public class UpdateProductCommandValidator :AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Product Id is required");
            RuleFor(c=>c.Name).NotEmpty().WithMessage("Name is required").Length(2,15).WithMessage("Name Must be between 2 and 150 Caharcters");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("Price Must be greter than 0");
        }
    }


    internal class UpdateProductCommandHandler (IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {

            logger.LogInformation("UpdateProductHandler has been called {@command}", command);
            var product = await session.LoadAsync<Model.Product>(command.Id, cancellationToken);
            if (product is null) 
            {
                throw new ProductNotFoundException();
            
            }

            product.Name=command.Name;
            product.Category=command.Category;
            product.ImageFile=command.ImageFile;
            product.Description=command.Discription;
            product.Price=command.Price;        

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);   
            return new UpdateProductResult(true);
        }

       
    }
}
