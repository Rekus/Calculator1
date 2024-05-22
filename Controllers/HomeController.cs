using Microsoft.AspNetCore.Mvc;
using Calculator1.Models;
using System.Diagnostics;
using Calculator1.Models;

namespace Calculator1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    switch (model.Operation)
                    {
                        case "+":
                            model.Result = model.Number1 + model.Number2;
                            break;
                        case "-":
                            model.Result = model.Number1 - model.Number2;
                            break;
                        case "*":
                            model.Result = model.Number1 * model.Number2;
                            break;
                        case "/":
                            if (model.Number2 == 0)
                            {
                                model.ErrorMessage = "Division by zero is not allowed.";
                            }
                            else
                            {
                                model.Result = model.Number1 / model.Number2;
                            }
                            break;
                        default:
                            model.ErrorMessage = "Invalid operation.";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    model.ErrorMessage = $"An error occurred: {ex.Message}";
                }
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

