using MediatR;

namespace CQRSPoc.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        decimal Price) : IRequest<Unit>;
}
