using CQRSPoc.Caching;
using CQRSPoc.Domain;
using CQRSPoc.Products.CreateProduct;
using MediatR;

namespace CQRSPoc.Proudcts.CreateProduct
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand,Unit>
    {
        private readonly ICacheService _cacheService;

        public CreateProductCommandHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

             await _cacheService.SetAsync("products", product, cancellationToken);

             return default;
        }
    }
}
