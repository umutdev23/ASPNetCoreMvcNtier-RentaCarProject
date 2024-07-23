using RentACar_Entity.Entities;
using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Services
{
    public interface ILocationService 
    {
        Task<IEnumerable<LocationViewModel>> GetAllAsync();
        Task<LocationViewModel> GetByIdAsync(int id);
        Task AddAsync(LocationViewModel model);
        void Update(LocationViewModel model);
        void Delete(LocationViewModel model);
        Task DeleteAsync(LocationViewModel model);
    }
}
