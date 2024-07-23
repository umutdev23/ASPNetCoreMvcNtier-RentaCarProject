using RentACar_Entity.Entities;
using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Entity.Services
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ReservationViewModel>> GetAllAsync();
        Task<ReservationViewModel> GetByIdAsync(int id);
        Task AddAsync(ReservationViewModel model);
        void Update(ReservationViewModel model);
        void Delete(ReservationViewModel model);
        Task DeleteAsync(ReservationViewModel model);
    }
}
