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
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(LocationViewModel model)
        {
            await _uow.GetRepository<Location>().AddAsync(_mapper.Map<Location>(model));
            await _uow.CommitAsync();
        }

        public void Delete(LocationViewModel model)
        {
            var entity = _mapper.Map<Location>(model);
            _uow.GetRepository<Location>().Delete(entity);
            _uow.Commit();
        }

        public async Task DeleteAsync(LocationViewModel model)
        {
            var entity = _mapper.Map<Location>(model);
            _uow.GetRepository<Location>().Delete(entity);
            _uow.Commit();
        }

        public async Task<IEnumerable<LocationViewModel>> GetAllAsync()
        {
            var list = await _uow.GetRepository<Location>().GetAllAsync();
            return _mapper.Map<List<LocationViewModel>>(list);
        }

        public async Task<LocationViewModel> GetByIdAsync(int id)
        {
            var location = await _uow.GetRepository<Location>().GetByIdAsync(id);
            return _mapper.Map<LocationViewModel>(location);    
        }

        public void Update(LocationViewModel model)
        {
           var entity = _mapper.Map<Location>(model);
            _uow.GetRepository<Location>().Update(entity);
            _uow.Commit();

        }
    }
}
