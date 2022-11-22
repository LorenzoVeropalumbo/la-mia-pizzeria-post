using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public PizzaDbContext db = new PizzaDbContext();

        public IActionResult Index()
        {          

            List<Pizza> listOfPizzas = db.Pizzas.ToList();

            return View(listOfPizzas);
        }

        public IActionResult Detail(int id)
        {

            Pizza pizza = db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            return View(pizza);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Pizzas.Add(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }


}
