using MediatR;

namespace CQRSPoc.Products.GetProducts
{
    public sealed record GetProductsQuery : IRequest<List<ProductResponse>>;
}
