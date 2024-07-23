using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Services
{
    public interface IModelService
    {
        Task<IEnumerable<ModelViewModel>> GetAllAsync();
        Task<ModelViewModel> GetByIdAsync(int id);
        Task AddAsync(ModelViewModel model);
        Task UpdateAsync(ModelViewModel model);
        Task DeleteAsync(ModelViewModel model);
    }
}
