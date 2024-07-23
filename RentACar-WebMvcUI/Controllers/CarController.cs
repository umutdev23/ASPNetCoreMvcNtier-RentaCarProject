using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar_Entity.Services;
using RentACar_Entity.ViewModels;
using System.Threading.Tasks;

namespace RentACar_WebMvcUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IModelService _modelService;
        private readonly ILocationService _locationService;
        private readonly IReservationService _reservationService;

        public CarController(ICarService carService, IModelService modelService, ILocationService locationService, IReservationService reservationService)
        {
            _carService = carService;
            _modelService = modelService;
            _locationService = locationService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllAsync();
            return View(cars);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Models = await _modelService.GetAllAsync();
            ViewBag.Locations = await _locationService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await _carService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Models = await _modelService.GetAllAsync();
            ViewBag.Locations = await _locationService.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewBag.Models = await _modelService.GetAllAsync();
            ViewBag.Locations = await _locationService.GetAllAsync();
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel model)
        {
            if (ModelState.IsValid)
            {
                _carService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Models = await _modelService.GetAllAsync();
            ViewBag.Locations = await _locationService.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> Deleted(CarViewModel model)
        {


            await _carService.DeleteAsync(model);
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public async Task<ActionResult> Filter()
        {
            var locations = await _locationService.GetAllAsync();
            ViewBag.Locations = new SelectList(locations, "Id", "City");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Filter(CarFilterViewModel filter)
        {
            var locations = await _locationService.GetAllAsync();
            ViewBag.Locations = new SelectList(locations, "Id", "City");

            var filteredCars = await _carService.GetFilteredCarsAsync(filter);
            return View("FilteredCars", filteredCars);
        }
    }
}
