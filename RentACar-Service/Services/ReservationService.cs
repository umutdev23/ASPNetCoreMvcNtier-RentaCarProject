using AutoMapper;
using RentACar_Entity.Entities;
using RentACar_Entity.Services;
using RentACar_Entity.UnitOfWorks;
using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Service.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ReservationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(ReservationViewModel model)
        {
            await _uow.GetRepository<Reservation>().AddAsync(_mapper.Map<Reservation>(model));
            await _uow.CommitAsync();
        }

        public void Delete(ReservationViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ReservationViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReservationViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReservationViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByDateAsync(DateTime startDate, DateTime endDate)
        {
            return _uow.GetRepository<Reservation>().GetAll().Where(r => r.StartDay <= endDate && r.EndDay >= startDate).ToList();
        }

        public void Update(ReservationViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
