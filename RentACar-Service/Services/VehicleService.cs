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
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public VehicleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task AddAsync(VehicleTypeViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(VehicleTypeViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetAllAsync()
        {
            var list = await _uow.GetRepository<VehicleType>().GetAllAsync();
            return _mapper.Map<List<VehicleTypeViewModel>>(list);
        }

        public Task<VehicleTypeViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(VehicleTypeViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
