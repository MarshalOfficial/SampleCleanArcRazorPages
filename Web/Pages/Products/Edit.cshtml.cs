using Application.Product.Commands.Update;
using Application.Product.Queries.GetProductDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.ViewModels.Product;

namespace Web.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public UpdateProductModel Product { get; set; } = new UpdateProductModel();

        public string ErrorMessage { get; set; }

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

            var result = await _mediator.Send(new UpdateProductRequest { Id = Product.Id, Name = Product.Name, Price = Product.Price });

            if (result.Succeed)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ErrorMessage = result.GetAllErrorMessages();
                return Page();
            }
        }
    }
}