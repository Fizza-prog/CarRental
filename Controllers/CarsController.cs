
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        // Available cars
        private static List<Car> availableCars = new List<Car>
        {
            new Car { Id = 1, Name = "Alto", PricePerDay = 3000 },
            new Car { Id = 2, Name = "Corolla", PricePerDay = 6000 },
            new Car { Id = 3, Name = "Civic", PricePerDay = 8000 }
        };

        // Booked cars
        private static List<Car> bookedCars = new List<Car>();

        // GET: /Cars/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }

        // POST: /Cars/Book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(int id)
        {
            Car? car = availableCars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return RedirectToAction("Index");
            }

            availableCars.Remove(car);
            bookedCars.Add(car);

            return RedirectToAction("Booked");
        }

        // GET: /Cars/Booked
        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}
