using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar_Entity.Services;
using RentACar_Entity.ViewModels;

namespace RentACar_WebMvcUI.Controllers
{
    public class AdminLocationController : Controller
    {
        private readonly ILocationService _locationService;

        public AdminLocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var locations = await _locationService.GetAllAsync();
            return View(locations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _locationService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                 _locationService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        [HttpPost]
        public async Task<IActionResult> Deleted(LocationViewModel model)
        {

            
                await _locationService.DeleteAsync(model);
                return RedirectToAction(nameof(Index));
            
           
        }
    }
}

