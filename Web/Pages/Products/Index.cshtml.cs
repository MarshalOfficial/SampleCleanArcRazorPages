using Application.Product.Queries.GetAllProducts;
using MediatR;
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
    }
}
