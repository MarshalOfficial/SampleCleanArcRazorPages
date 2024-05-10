using Application.Product.Commands.Update;
using Application.Product.Queries.GetProductDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public UpdateProductRequest Product { get; set; } = new UpdateProductRequest();

        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _mediator.Send(new GetProductDetailsRequest(id.Value));

            if (result == null)
            {
                return NotFound();
            }

            Product.Id = result.Id;
            Product.Name = result.Name;
            Product.Price = result.Price;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _mediator.Send(Product);

            return RedirectToPage("./Index");
        }
    }
}
