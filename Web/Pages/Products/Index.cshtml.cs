using Application.Product.Queries.GetAllProducts;
using Application.Product.Queries.GetProductDetails;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Products
{
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
    }
}   