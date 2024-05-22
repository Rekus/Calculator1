using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator1.Home
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public double Number1 { get; set; }

        [BindProperty]
        public double Number2 { get; set; }

        [BindProperty]
        public string? Operation { get; set; }

        public double? Result { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                if (string.IsNullOrEmpty(Operation))
                {
                    ErrorMessage = "Operation is not selected.";
                    return;
                }

                switch (Operation)
                {
                    case "+":
                        Result = Number1 + Number2;
                        break;
                    case "-":
                        Result = Number1 - Number2;
                        break;
                    case "*":
                        Result = Number1 * Number2;
                        break;
                    case "/":
                        if (Number2 == 0)
                        {
                            ErrorMessage = "Division by zero is not allowed.";
                        }
                        else
                        {
                            Result = Number1 / Number2;
                        }
                        break;
                    default:
                        ErrorMessage = "Invalid operation.";
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
        }
    }
}

