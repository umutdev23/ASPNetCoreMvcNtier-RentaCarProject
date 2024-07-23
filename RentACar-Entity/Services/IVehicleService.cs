using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleTypeViewModel>> GetAllAsync();
        Task<VehicleTypeViewModel> GetByIdAsync(int id);
        Task AddAsync(VehicleTypeViewModel model);
        Task UpdateAsync(VehicleTypeViewModel model);
        Task DeleteAsync(VehicleTypeViewModel model);
    }
}
