using Microsoft.AspNetCore.Mvc;
using priceQuotation.Models;

namespace priceQuotation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.DiscountAmount = 0;
            ViewBag.total = 0;
            // Return an empty model to the view for the first GET request
            return View();
        }

        [HttpPost]
        public IActionResult Index(PriceQuotationModel model)
        {
            if (ModelState.IsValid)
            {
                // Calculate the discount amount
                ViewBag.DiscountAmount = model.DiscountAmount();

                // Calculate the total after applying the discount
                ViewBag.total = model.Total();
            }
            else
            {
                ViewBag.DiscountAmount = 0;
                ViewBag.total = 0;
            }
            // If model state is invalid, just return the model back to the view without calculation
            return View(model);
        }
    }
}
