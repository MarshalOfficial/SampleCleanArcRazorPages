using Application.Product.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.ViewModels.Product;

namespace Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public AddProductModel Product { get; set; } = new AddProductModel();

        public string ErrorMessage { get; set; }


        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _mediator.Send(new CreateProductRequest { Name = Product.Name, Price = Product.Price });

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
