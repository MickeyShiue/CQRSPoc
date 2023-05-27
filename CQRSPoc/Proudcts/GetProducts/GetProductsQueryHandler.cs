using CQRSPoc.Caching;
using MediatR;

namespace CQRSPoc.Products.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponse>>
    {
        private readonly ICacheService _cacheService;

        public GetProductsQueryHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _cacheService.GetAsync<ProductResponse>("products", cancellationToken);
            return new List<ProductResponse>() { product };
        }
    }
}
