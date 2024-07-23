using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RentACar_Entity.Entities;
using RentACar_Entity.Services;
using RentACar_Entity.UnitOfWorks;
using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Service.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IReservationService _reservationService;
        public CarService(IUnitOfWork uow, IMapper mapper, IReservationService reservationService)
        {
            _uow = uow;
            _mapper = mapper;
            _reservationService = reservationService;
        }



        public async Task AddAsync(CarViewModel model)
        {
            await _uow.GetRepository<Car>().AddAsync(_mapper.Map<Car>(model));
            await _uow.CommitAsync();
        }

        public void Delete(CarViewModel model)
        {
            var entity = _mapper.Map<Car>(model);
            _uow.GetRepository<Car>().Delete(entity);
            _uow.Commit();
        }

        public async Task DeleteAsync(CarViewModel model)
        {
            var entity = _mapper.Map<Car>(model);
            _uow.GetRepository<Car>().Delete(entity);
            _uow.Commit();
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync()
        {
            var list = await _uow.GetRepository<Car>().GetAllAsync(includes: new Expression<Func<Car, object>>[]
                 {
                c => c.Model,
                c => c.Model.Brand,
                c => c.Model.VehicleType
                });
            return _mapper.Map<List<CarViewModel>>(list);
        }

        public async Task<CarViewModel> GetByIdAsync(int id)
        {
            var car = await _uow.GetRepository<Car>().GetByIdAsync(filter: x => x.Id == id , includes: new Expression<Func<Car, object>>[]
                 {
                c => c.Model,
                c => c.Model.Brand,
                c => c.Model.VehicleType
                });
            return _mapper.Map<CarViewModel>(car);
        }
        public void Update(CarViewModel model)
        {
            var entity = _mapper.Map<Car>(model);
            _uow.GetRepository<Car>().Update(entity);
            _uow.Commit();
        }

        public async Task<IEnumerable<CarViewModel>> GetFilteredCarsAsync(CarFilterViewModel filter)
        {

            var query = await _uow.GetRepository<Car>().GetAllAsync(includes: new Expression<Func<Car, object>>[]
                 {
                c => c.Model,
                c => c.Model.Brand,
                c => c.Model.VehicleType
                }
                    );
            if (filter.VehicleTypeId != null && filter.VehicleTypeId.Any())
            {

                query = query.Where(c => filter.VehicleTypeId.Contains(c.Model.VehicleTypeId)); //burada hata alıyoruz, vehicletype car entity içine aktarmak zorunda mıyız başka bir şekilde ilişki yapabilir miyiz?
            }
            if (filter.PickupLocationId.HasValue)
            {
                query = query.Where(c => c.LocationId == filter.PickupLocationId);
            }
            if (filter.PickupLocationId != filter.ReturnLocationId)
            {
                //modele ek ücret yansıtılacak
            }


            var reservedCars = await _reservationService.GetReservationsByDateAsync(filter.PickupDate, filter.ReturnDate);
            var reservedCarIds = reservedCars.Select(r => r.CarId).Distinct();

            query = query.Where(c => !reservedCarIds.Contains(c.Id));

            var cars = query.ToList();
            return _mapper.Map<List<CarViewModel>>(cars);
        }


    }
    
}
