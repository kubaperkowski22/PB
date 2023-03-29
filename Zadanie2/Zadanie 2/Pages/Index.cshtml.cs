using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using Zadanie_2.Forms;

namespace Zadanie_2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Zadanie2Form Zadanie2Form { get; set; }

    

        public string Name { get; set; }
        public string Message => GetMessage(Zadanie2Form.Number);
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public string GetMessage(int Number)
        {
            
            if (Number % 5 == 0 && Number % 3 == 0) { return "FizzBuzz"; }
            if (Number % 5 == 0) { return "Buzz"; }
            if (Number % 3 == 0) { return "Fizz"; }
            else return $"Liczba {Number} nie spełnia kryteriów FizzBuzz";
        }
        public IActionResult OnPost()
        {
              return Page();
           

           // return RedirectToPage("./Privacy");
        }
    }
}