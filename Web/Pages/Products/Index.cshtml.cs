using Application.Product.Commands.Delete;
using Application.Product.Queries.GetAllProducts;
using Application.Product.Queries.GetProductDetails;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Products
{
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        private readonly IMediator mediator;

        public IndexModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public List<ProductDto> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await mediator.Send(new GetAllProductsRequest());
        }

        public async Task<IActionResult> OnGetProductDetails(int id)
        {
            var result = await mediator.Send(new GetProductDetailsRequest(id));

            return Partial("_Details", result);
        }


        public async Task<IActionResult> OnPostDeleteProduct([FromForm] int id)
        {
            var result = await mediator.Send(new DeleteProductRequest(id));

            if (result)
            {
                return new JsonResult(new { success = true });
            }
            else
            {
                return new JsonResult(new { success = false, message = "Product not found or deletion failed." });
            }
        }
    }
}