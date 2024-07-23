using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllAsync();
        Task<CarViewModel> GetByIdAsync(int id);
        Task AddAsync(CarViewModel model);
        //List<CarViewModel> GetAll();
        void Update(CarViewModel model);
        void Delete(CarViewModel model);
        Task DeleteAsync(CarViewModel model);

        //Filters
        Task<IEnumerable<CarViewModel>> GetFilteredCarsAsync(CarFilterViewModel filter);
    }
}
