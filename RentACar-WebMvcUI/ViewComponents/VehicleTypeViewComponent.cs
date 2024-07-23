using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentACar_Entity.Services;
using RentACar_Entity.ViewModels;

namespace RentACar_WebMvcUI.ViewComponents
{
    public class VehicleTypeViewComponent : ViewComponent
    {
        private readonly IVehicleService _vehicleService;

        public VehicleTypeViewComponent(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await _vehicleService.GetAllAsync();
            return View(list);
        }
    }
}
