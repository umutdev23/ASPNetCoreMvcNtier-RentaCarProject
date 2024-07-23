using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentACar_Entity.Entities;
using RentACar_Entity.Services;
using RentACar_Entity.ViewModels;
using RentACar_Service.Services;
using RentACar_WebMvcUI.Models;
using System.Diagnostics;

namespace RentACar_WebMvcUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IVehicleService _vehicleTypeService;
        private readonly ILocationService _locationService;
        private readonly ICarService _carService;
        private readonly IReservationService _reservationService;
        public HomeController(ILogger<HomeController> logger, IVehicleService vehicleTypeService, ILocationService locationService, ICarService carService, IReservationService reservationService)
        {
            _logger = logger;
            _vehicleTypeService = vehicleTypeService;
            _locationService = locationService;
            _carService = carService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
		{
            ViewBag.Locations = await _locationService.GetAllAsync();
            ViewBag.Models = await _vehicleTypeService.GetAllAsync();



            var model = new CarFilterViewModel();
            
            return View(model);
		}
        [HttpPost]
       
        public async Task<IActionResult> Filter(CarFilterViewModel filter)
        {
            var locations = await _locationService.GetAllAsync();
            ViewBag.Locations = new SelectList(locations, "Id", "City");

            ViewBag.Locations = await _locationService.GetAllAsync();

              ViewBag.PickUpLocation = filter.ReturnLocationId; 
              ViewBag.PickUpDate = filter.PickupDate;
              ViewBag.ReturnDate = filter.ReturnDate; 
            ViewBag.Models = await _vehicleTypeService.GetAllAsync();
            var filteredCars = await _carService.GetFilteredCarsAsync(filter);

            if (ViewBag.SelectedVehicleTypes != null)
            {
                ViewBag.SelectedVehicleTypes = filter.Model.VehicleType;
            }
            if (ViewBag.SelectedFuelTypes != null)
            {
                ViewBag.SelectedFuelTypes = filter.Model.FuelType;
            }
            if (ViewBag.SelectedTransmissionTypes != null)
            {
                ViewBag.SelectedTransmissionTypes = filter.Model.GearBoxType;
            }
            if (filter.PickupDate >= filter.ReturnDate)
            {

                ModelState.AddModelError(string.Empty, "Araç alýþ tarihi, araç býrakma tarihinden erken olamaz.");

                ViewBag.Locations = await _locationService.GetAllAsync();


                return View("Index");
            }

            return View("FilteredCars", filteredCars);

        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> Cars(int? id)
        {
            var carList = await _carService.GetAllAsync();

            if (id != null)
            {
                carList = carList.Where(x => x.Model.VehicleTypeId == id);
            }

            return View(carList);
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Corporation()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CarDetail(int id, DateTime startDate, DateTime endDate)
        {
            var car = await _carService.GetByIdAsync(id);
            ViewBag.Reservation = new ReservationViewModel
            {
                CarId = id,
                StartDay = startDate,
                EndDay = endDate,
                TotalPrice = (endDate.Day - startDate.Day) * car.Price
            };
            
            
            
            return View(car);
        }
        public async Task<IActionResult> ConfirmPayment(int id, DateTime startDate, DateTime endDate)
        {
            var car = await _carService.GetByIdAsync(id);
            ViewBag.Reservation = new ReservationViewModel
            {
                CarId = id,
                StartDay = startDate,
                EndDay = endDate,
                TotalPrice = (endDate.Day - startDate.Day) * car.Price
            };
            
            return View(car);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public async Task<IActionResult> ConfirmedPayment(int id, DateTime startDate, DateTime endDate)
        {
            var car = await _carService.GetByIdAsync(id);
            var reservation = new Reservation()
            {
                CarId = id,
                CustomerUserId =1,
                StartDay=startDate,
                EndDay=endDate,
                TotalPrice = (endDate.Day- startDate.Day) * car.Price,
            };

            //reservationService.AddAsync(reservation);

            return View(car);
        }
    }
}
