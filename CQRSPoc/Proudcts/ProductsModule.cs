using Carter;
using CQRSPoc.Products.CreateProduct;
using CQRSPoc.Products.GetProducts;
using MediatR;
using Presentation.Products;

namespace CQRSPoc.Products
{
    public class ProductsModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());

                return result;
            });

            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var createProductCommand = new CreateProductCommand(request.Name, request.Price);
                
                await sender.Send(createProductCommand);

                return Results.Ok();
            });
        }
    }
}
