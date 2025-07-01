
namespace Basket.API.Basket.GetBasket
{
 
    public record GetBasketQuery(string Name) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCartItem);
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
