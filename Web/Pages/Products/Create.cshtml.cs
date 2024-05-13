using Application.Product.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        [BindProperty]
        public CreateProductRequest Product { get; set; } = new CreateProductRequest();

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

            var result = await _mediator.Send(Product);

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
